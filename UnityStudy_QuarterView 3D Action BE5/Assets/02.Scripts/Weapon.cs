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
    public Type type;
    // 무기 데미지
    public int damage;
    // 공격 속도    
    public float rate;
    // 전체 탄약
    public int maxAmmo;
    // 현재 탄약
    public int curAmmo;
    // 공격 범위
    public BoxCollider meleeArea;
    // 효과 변수
    public TrailRenderer trailEffect;

    public Transform bulletPos;
    public GameObject bullet;
    public Transform bulletCasePos;
    public GameObject bulletCase;

    public void Use()
    {
        if (type == Type.Melee)
        {
            StopCoroutine("Swing");
            StartCoroutine("Swing");
        }
        if (type == Type.Range && curAmmo > 0)
        {
            // 총알 소모
            curAmmo--;
            StartCoroutine("Shot");
        }
    }

    // IEnumerator : 열거형 함수 클래스
    // yield : 결과를 전달하는 키워드 | yield 키워드를 여러 개 사용하여 시간차 로직 작성 가능
    // WaitForSeconds(time) - 대기 함수
    // yield break로 코루틴 탈출 가능
    IEnumerator Swing()
    {
        yield return new WaitForSeconds(0.4f); // 0.4초 대기
        meleeArea.enabled = true;
        trailEffect.enabled = true;

        yield return new WaitForSeconds(0.3f);
        meleeArea.enabled = false;

        yield return new WaitForSeconds(0.3f);
        trailEffect.enabled = false;
    }

    IEnumerator Shot()
    {
        // #1. 총알 발사
        GameObject intantBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
        Rigidbody bulletRb = intantBullet.GetComponent<Rigidbody>();
        bulletRb.velocity = bulletPos.forward * 50;

        yield return null;
        // #2. 탄피 배출
        GameObject intantCase = Instantiate(bulletCase, bulletCasePos.position, bulletCasePos.rotation);
        Rigidbody CaseRb = intantBullet.GetComponent<Rigidbody>();
        // 힘을 가하기 전에 탄피가 나갈 방향을 설정해준다.
        Vector3 caseVec = bulletCasePos.forward * Random.Range(-3, -2) + Vector3.up * Random.Range(2, 3);
        CaseRb.AddForce(caseVec, ForceMode.Impulse);
        CaseRb.AddTorque(Vector3.up * 10, ForceMode.Impulse);
    }
    // 일반함수   :: Use() 메인루틴 -> Swing() 서브루틴 -> Use() 메인루틴(교차실행)
    // 코루틴함수 :: Use() 메인루틴 + Swing() 코루틴(동시실행)
}
