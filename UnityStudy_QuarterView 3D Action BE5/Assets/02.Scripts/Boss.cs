using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : Enemy
{
    public GameObject missaile;
    public Transform  missailePortA;
    public Transform  missailePortB;
    // 플레이어 바라보는 플래그 bool 변수
    public bool isLook;

    // 플레이어의 이동을 예측하는 로직
    Vector3 lookVec;
    Vector3 tauntVec;

    void Awake()
    {
        // 부모 스크립트를 Start()로 바꾸면 모든 정보가 바뀌므로 자식 스크립트에서 다시 불러온다.(임시)
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
        meshs = GetComponentsInChildren<MeshRenderer>();
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();

        nav.isStopped = true;
        StartCoroutine(Think());  
    }

    void Update()
    {
        // 죽었을 때 모든 코루틴을 정지시키고 반환
        if (isDead)
        {
            StopAllCoroutines();
            return;
        }

        if (isLook)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            lookVec = new Vector3(h, 0, v) * 5f;
            transform.LookAt(target.position + lookVec);
        }
        else // (!isLook)
        {
            // 점프공격 할 때 목표지점으로 이동하도록 한다.
            nav.SetDestination(tauntVec);
        }
    }

    IEnumerator Think()
    {
        yield return new WaitForSeconds(0.1f);
        int randomAction = Random.Range(0, 5); // 0, 1, 2, 3, 4

        switch (randomAction)
        {
            case 0:
            case 1:
                // 미사일 발사 패턴
                StartCoroutine(MissaileShot());
                break;
            case 2:
            case 3:
                // 돌 굴러가는 패턴
                StartCoroutine(RockShot());
                break;
            case 4:
                // 점프 공격 패턴
                StartCoroutine(Taunt());
                break;
        }
    }
    
    // 3종 패턴을 담당할 코루틴 생성
    IEnumerator MissaileShot()
    {
        anim.SetTrigger("doShot");
        yield return new WaitForSeconds(0.2f);
        // 생성
        GameObject instantMissaileA = Instantiate(missaile, missailePortA.position, missailePortA.rotation);
        // 미사일 스크립트까지 접근하여 목표물 설정해주기
        BossMissile bossMissileA = instantMissaileA.GetComponent<BossMissile>();
        bossMissileA.target = target;

        yield return new WaitForSeconds(0.3f);
        // 생성
        GameObject instantMissaileB = Instantiate(missaile, missailePortB.position, missailePortB.rotation);
        // 미사일 스크립트까지 접근하여 목표물 설정해주기
        BossMissile bossMissileB = instantMissaileB.GetComponent<BossMissile>();
        bossMissileB.target = target;

        // 패턴 끝
        yield return new WaitForSeconds(2.0f);
        StartCoroutine(Think());
    }

    IEnumerator RockShot()
    {
        // 기 모을 때는 바라보기 중지하도록 플래그 변환
        isLook = false;
        anim.SetTrigger("doBigShot");
        // 생성
        Instantiate(bullet, transform.position, transform.rotation);

        // 패턴 끝
        yield return new WaitForSeconds(3f);
        isLook = true;
        StartCoroutine(Think());
    }

    IEnumerator Taunt()
    {
        // 점프 공격을 할 위치를 변수에 저장
        tauntVec = target.position + lookVec;

        isLook        = false;
        nav.isStopped = false;
        // 콜라이더가 플레이어를 밀지 않도록 비활성화
        bc.enabled    = false;
        anim.SetTrigger("doTaunt");

        yield return new WaitForSeconds(1.5f);
        meleeArea.enabled = true;

        yield return new WaitForSeconds(0.5f);
        meleeArea.enabled = false;

        // 패턴 끝
        yield return new WaitForSeconds(1f);
        // 패턴 끝났으니 복구
        isLook        = true;
        nav.isStopped = true;
        bc.enabled    = true;
        StartCoroutine(Think());
    }
    
}
