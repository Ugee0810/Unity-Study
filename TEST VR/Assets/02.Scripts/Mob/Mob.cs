using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Mob : MonoBehaviour
{
    // 델리게이트 이벤트와 유사한 유니티 이벤트(using 선언)
    public UnityEvent OnCreated;
    public UnityEvent OnDestroyed;

    private bool isDestroyed = false;

    public float destroyDelay = 1f;

    private void Start()
    {
        // 사망
        Invoke(nameof(Destroy), 3f);
        
        OnCreated?.Invoke();
    }

    public void Destroy()
    {
        if (isDestroyed) return;           // 이미 죽은 상태일 경우 탈출(재호출 방지)
        isDestroyed = true;                // 플래그 변수 전환
        //destroyParticle.Play();            // 사망 파티클 재생
        //destroyAudio.Play();               // 사망 사운드 재생
        //environmentParticle.Stop();        // 환경 파티클 멈춤
        //agent.enabled = false;             // AI 추적 비활성화
        //modelGameObject.SetActive(false);  // 오브젝트 모델(바디) 비활성화
        Destroy(gameObject, destroyDelay); // 오브젝트 제거

        OnDestroyed?.Invoke();
    }
}
