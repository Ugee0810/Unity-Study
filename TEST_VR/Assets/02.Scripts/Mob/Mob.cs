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

    public float destroyDelay = 1f;
    private bool isDestroyed = false;

    public MeshRenderer   holeMeshRenderer;    // 호박 눈 색깔 바꾸기
    public ParticleSystem environmentParticle; // 환경 파티클
    public ParticleSystem destroyParticle;     // 사망 파티클
    public AudioSource    destroyAudio;        // 사망 사운드
    public GameObject modelGameObject;

    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        // 플레이어가 서 있는 곳으로 찾아온다.
        agent.SetDestination(new Vector3(0f, 2f, 1f));
        agent.speed *= Random.Range(0.8f, 1.5f);

        // 랜덤 컬러 함수
        RandomColor();

        // 사망
        Invoke(nameof(Destroy), 3f);

        
        OnCreated?.Invoke();
    }

    void RandomColor()
    {
        // holeMeshRenderer
        holeMeshRenderer.material.SetColor("_EmissionColor", color * emisionIntensity);


        // destroyParticle
        main = destroyParticle.main;
        main.startColor = new ParticleSystem.MinMaxGradient(color,
                                                            color * Random.Range
                                                           (1f - arrangeRange,
                                                            1f + arrangeRange));

        renderer = destroyParticle.GetComponent<ParticleSystemRenderer>();
        renderer.material.SetColor("_EmissionColor", color * emisionIntensity);
    }

    public void Destroy()
    {
        if (isDestroyed) return;           // 이미 죽은 상태일 경우 탈출(재호출 방지)
        isDestroyed = true;                // 플래그 변수 전환
        //destroyParticle.Play();            // 사망 파티클 재생
        //destroyAudio.Play();               // 사망 사운드 재생
        environmentParticle.Stop();        // 환경 파티클 멈춤
        agent.enabled = false;             // AI 추적 비활성화
        modelGameObject.SetActive(false);  // 오브젝트 모델(바디) 비활성화
        Destroy(gameObject, destroyDelay); // 오브젝트 제거

        OnDestroyed?.Invoke();
    }
}
