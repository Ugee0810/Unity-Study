using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum Type
    {
        Melee,
        Range
    }

    // 무기 타입
    public Type  type;
    // 무기 데미지
    public int   damage;
    // 공격 속도    
    public float rate;
    // 공격 범위
    public BoxCollider meleeArea;
    // 효과 변수
    public TrailRenderer trailEffect;

    public void Use()
    {
        if (type == Type.Melee)
        {
            StopCoroutine("Swing");
            StartCoroutine("Swing");
        }
    }

    // IEnumerator : 열거형 함수 클래스
    // yield : 결과를 전달하는 키워드 | yield 키워드를 여러 개 사용하여 시간차 로직 작성 가능
    // WaitForSeconds(time) - 대기 함수
    // yield break로 코루틴 탈출 가능
    IEnumerator Swing()
    {
        yield return new WaitForSeconds(0.1f); // 0.1초 대기
        meleeArea.enabled = true;
        trailEffect.enabled = true;

        yield return new WaitForSeconds(0.3f);
        meleeArea.enabled = false;

        yield return new WaitForSeconds(0.3f);
        trailEffect.enabled = false;
    }

    // 일반함수   :: Use() 메인루틴 -> Swing() 서브루틴 -> Use() 메인루틴(교차실행)
    // 코루틴함수 :: Use() 메인루틴 + Swing() 코루틴(동시실행)
}
