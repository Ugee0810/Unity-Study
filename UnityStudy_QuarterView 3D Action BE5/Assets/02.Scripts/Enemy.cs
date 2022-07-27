using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public enum Type
    {
        // 일반
        A,
        // 돌격
        B,
        // 원거리
        C,
        // 보스
        D,
    }
    public Type enemyType;

    public int maxHelath;
    public int curHelath;
    public int score;
    public GameManager manager;
    public Transform target;
    // 공격 범위
    public BoxCollider meleeArea;
    public CapsuleCollider rangeArea;
    public GameObject bullet;
    public GameObject[] coins;
    // 추적을 결정하는 변수
    public bool isChase;
    public bool isAttack;
    public bool isDead;

    public Rigidbody rb;
    public BoxCollider bc;
    public MeshRenderer[] meshs;
    public NavMeshAgent nav;
    public Animator anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
        // Material을 가져오려면 아래의 구문처럼 한다.
        meshs = GetComponentsInChildren<MeshRenderer>();
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();

        if (enemyType != Type.D)
            Invoke("ChaseStart", 2);
    }

    void ChaseStart()
    {
        isChase = true;
        anim.SetBool("isWalk", true);
    }

    void Update()
    {
        // 네비게이션이 활성화 되어 있을 때만(플레이어가 죽고 나서도 움직이는 걸 방지)
        // SetDestination() - 도착할 목표 위치 지정 함수
        // nav.isStopped를 사용하여 완벽하게 멈추도록 작성
        if (nav.enabled && enemyType != Type.D)
        {
            nav.SetDestination(target.position);
            nav.isStopped = !isChase;
        }
    }

    void Targeting()
    {
        if (!isDead && enemyType != Type.D)
        {
            float targetRadius = 0f;
            float targetRange  = 0f;

            // switch문으로 각 타겟팅 수치 정하기
            switch (enemyType)
            {
                case Type.A:
                    targetRadius = 1.5f;
                    targetRange  = 3f;
                    break;
                case Type.B:
                    targetRadius = 1f;
                    targetRange  = 12f;
                    break;
                case Type.C:
                    targetRadius = 0.5f;
                    targetRange  = 25f;
                    break;
            }

            // SphereCastAll() - 구체 모양의 레이캐스팅(모든 물체)
            RaycastHit[] rayHits = Physics.SphereCastAll(transform.position, // 자신의 위치
                                                         targetRadius,       // 구체 반지름
                                                         transform.forward,  // 방향 = 몬스터의 앞
                                                         targetRange,        // 거리
                                                         LayerMask.GetMask("Player"));
            // rayHit 변수에 데이터가 들어오면 공격 코루틴 실행
            // 공격 후에 연속으로 공격하는걸 방지(!isAttack)
            if (rayHits.Length > 0 && !isAttack)
            {
                StartCoroutine(Attack());
            }
        }
    }

    IEnumerator Attack()
    {
        isChase = false;
        isAttack = true;
        anim.SetBool("isAttack", true);

        switch (enemyType)
        {
            case Type.A:
                // Type.A : 정지 -> 공격 -> 추적 개시
                // 애니메이션과 맞추기 위해 딜레이를 준다.
                yield return new WaitForSeconds(0.2f);
                meleeArea.enabled = true;

                yield return new WaitForSeconds(1f);
                meleeArea.enabled = false;

                yield return new WaitForSeconds(1f);
                break;
            case Type.B:
                yield return new WaitForSeconds(0.1f);
                rb.AddForce(transform.forward * 20, ForceMode.Impulse);
                meleeArea.enabled = true;

                yield return new WaitForSeconds(0.5f);
                rb.velocity = Vector3.zero;
                meleeArea.enabled = false;

                yield return new WaitForSeconds(2f);
                break;
            case Type.C:
                yield return new WaitForSeconds(0.5f);
                GameObject instantBullet = Instantiate(bullet, transform.position, transform.rotation);
                Rigidbody rbBullet = instantBullet.GetComponent<Rigidbody>();
                rbBullet.velocity = transform.forward * 20;

                yield return new WaitForSeconds(2f);
                break;
        }
        isChase = true;
        isAttack = false;
        anim.SetBool("isAttack", false);
    }

    void FreezeVelocity()
    {
        if (isChase)
        {
            // 물리력이 NavAgent 이동을 방해하지 않도록 로직 추가
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    void FixedUpdate()
    {
        Targeting();
        FreezeVelocity();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Melee")
        {
            Weapon weapon = collision.GetComponent<Weapon>();
            curHelath -= weapon.damage;

            // 현재 위치에 피격 위치를 빼서 반작용 방향 구하기
            Vector3 reactVec = transform.position - collision.transform.position;

            StartCoroutine(OnDamage(reactVec, false));
        }
        else if (collision.tag == "Bullet")
        {
            Bullet bullet = collision.GetComponent<Bullet>();
            curHelath -= bullet.damage;

            // 현재 위치에 피격 위치를 빼서 반작용 방향 구하기
            Vector3 reactVec = transform.position - collision.transform.position;
            // 충돌한 총알 삭제
            Destroy(collision.gameObject);

            StartCoroutine(OnDamage(reactVec, false));
        }
    }

    public void HitByGrenade(Vector3 explosionPos)
    {
        curHelath -= 100;
        Vector3 reactVec = transform.position - explosionPos;
        StartCoroutine(OnDamage(reactVec, true));
    }

    IEnumerator OnDamage(Vector3 reactVec, bool isGrenade)
    {
        // foreach문으로 메쉬렌더러를 한 번에 바꾼다.
        foreach (MeshRenderer mesh in meshs)
            mesh.material.color = Color.red;

        yield return new WaitForSeconds(0.05f);

        if (curHelath > 0)
        {
            foreach (MeshRenderer mesh in meshs) mesh.material.color = Color.white;
        }
        else // Died
        {
            foreach (MeshRenderer mesh in meshs) mesh.material.color = Color.gray;
            gameObject.layer = 14; // 14번 레이어로 변경(Enemy Dead)
            isDead = true;
            isChase = false;
            nav.enabled = false; // 사망 리액션을 유지하기 위해 NavAgent를 비활성
            anim.SetTrigger("doDie");

            // 점수 부여
            Player player = target.GetComponent<Player>();
            player.score += score;

            // 동전 드랍
            int randomCoin = Random.Range(0, 3);
            Instantiate(coins[randomCoin], transform.position, Quaternion.identity);

            // 카운트 감소
            switch (enemyType)
            {
                case Type.A:
                    manager.enemyCntA--;
                    break;
                case Type.B:
                    manager.enemyCntB--;
                    break;
                case Type.C:
                    manager.enemyCntC--;
                    break;
                case Type.D:
                    manager.enemyCntD--;
                    break;
                default:
                    break;
            }

            if (isGrenade)
            {
                // 방향은 방향대로 밀려나는 값이 통일됨
                reactVec = reactVec.normalized;
                reactVec += Vector3.up * 3;

                // 수류탄에 의한 사망 리액션은 큰 힘과 회전을 추가
                // RigidBody 속성의 X, Z로테이션을 체크 해제한다.
                rb.freezeRotation = false;
                rb.AddForce(reactVec * 5, ForceMode.Impulse);
                rb.AddTorque(reactVec * 20, ForceMode.Impulse);
            }
            else
            {
                reactVec = reactVec.normalized;
                reactVec += Vector3.up;

                rb.AddForce(reactVec * 5, ForceMode.Impulse);      
            }
            Destroy(gameObject, 4f);
        }
    }
}
