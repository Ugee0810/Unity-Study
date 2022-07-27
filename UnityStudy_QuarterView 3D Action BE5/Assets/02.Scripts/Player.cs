using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float jumpPower;
    public GameObject[] weapons;
    public bool[] hasWeapons;
    public GameObject[] granades;
    public int hasGranades;
    public GameObject granadeObj;
    public Camera followCamera;
    public GameManager manager;

    public AudioSource jumpSound;

    public int ammo;
    public int coin;
    public int health;
    public int score;

    public int maxAmmo;
    public int maxCoin;
    public int maxHealth;
    public int maxHasGranades;

    float hAxis;
    float vAxis;
    bool  wDown;
    bool  jDown;
    bool  fDown;
    bool  gDown;
    bool  rDown;
    bool  iDown;
    // 무기 교체
    bool sDown1;
    bool sDown2;
    bool sDown3;

    bool isJump;
    bool isDodge;
    bool isSwap;
    bool isFireReady = true;
    bool isReload;
    bool isBorder;
    bool isDamage;
    bool isShop;
    bool isDead;

    Vector3 moveVec;
    Vector3 dodgeVec;

    Animator anim;
    Rigidbody rb;
    // 플레이어의 오브젝트(팔, 다리, 몸 등)이 많으므로 배열로 가져오기
    MeshRenderer[] meshs;

    // 트리거 된 아이템을 저장하기 위한 변수
    GameObject nearObject;
    // 기존에 장착된 무기를 저장하는 변수
    public Weapon equipWeapon;
    int equipWeaponIndex = -1;
    // 공격 준비 딜레이 변수
    float fireDelay;

    void Awake()
    {
        // GetComponentInChildren<>() - 자식 오브젝트에 있는 컴포넌트를 가져온다.
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        // GetComponentsInChildren<>() - 메쉬렌더러를 가지고 있는 자식 오브젝트를 모두 가져온다.
        meshs = GetComponentsInChildren<MeshRenderer>();
    }

    void Update()
    {
          GetInput();
              Move();
              Turn();
              Jump();
             Dodge();
        Interation();
              Swap();
            Attack();
            Reload();
           Granade();
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        // Input.GetButton() - 누를 때 적용 및 유지
        wDown = Input.GetButton("Walk");
        jDown = Input.GetButtonDown("Jump");
        iDown = Input.GetButtonDown("Interation");
        fDown = Input.GetButton("Fire1");
        gDown = Input.GetButtonDown("Fire2");
        rDown = Input.GetButtonDown("Reload");
        sDown1 = Input.GetButtonDown("Swap1");
        sDown2 = Input.GetButtonDown("Swap2");
        sDown3 = Input.GetButtonDown("Swap3");
    }

    void Move()
    {
        // normalized - 어떤 방향이든 값이 1로 보정된 벡터(ft.대각선)
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;
        // 회피 중에는 움직임 벡터 -> 회피 방향 벡터로 바뀌도록 구현
        if (isDodge) moveVec = dodgeVec;
        // 스왑 중, 재장전 중, 사격 가능 상태, 죽었을 때 움직임 없애기
        if (isSwap || isReload || !isFireReady || isDead) moveVec = Vector3.zero;
        // Move if : Ray에 의해 RayMask인 Wall이 캐치될 경우엔 더하지 않는걸로 회전은 할 수 있게 한다.
        // 삼항 연산자로 Walk 컨트롤
        if (!isBorder) transform.position += moveVec * moveSpeed * (wDown ? 0.3f : 1f) * Time.deltaTime;
        // Animation
        anim.SetBool("isRun", moveVec != Vector3.zero);
        anim.SetBool("isWalk", wDown);
    }

    void Turn()
    {
        //// 1.키보드에 의한 회전
        // transform.LookAt() - 지정된 벡터를 향해서 회전시켜주는 함수
        transform.LookAt(transform.position + moveVec);

        //// 2.마우스에 의한 회전
        if (fDown)
        {
            if (isDead) return;

            // ScreenPointToRay() - 스크린에서 월드로 Ray를 쏘는 함수
            Ray ray = followCamera.ScreenPointToRay(Input.mousePosition);
            // RaycastHit 정보를 저장할 변수
            RaycastHit rayHit;
            // out : return처럼 반환값을 주어진 변수에 저장하는 키워드
            if (Physics.Raycast(ray, out rayHit, 100))
            {
                // RayCastHit의 마우스 클릭 위치 활용하여 회전을 구현
                Vector3 nextVec = rayHit.point - transform.position;
                // RayCastHit의 높이는 무시하도록 Y축 값을 0으로 초기화
                nextVec.y = 0;
                transform.LookAt(transform.position + nextVec);
            }
        }
    }

    void Jump()
    {
        // jDown && 정지 상태 && 점프 중 아닐 때 && 회피 중 아닐 때
        if (jDown && moveVec == Vector3.zero && !isJump && !isDodge && !isDead)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);

            anim.SetTrigger("doJump");
            anim.SetBool("isJump", true);
            isJump = true;

            jumpSound.Play();
        }
    }

    void Dodge()
    {
        if (jDown && moveVec != Vector3.zero && !isJump && !isDodge && !isSwap && !isDead)
        {
            dodgeVec = moveVec;
            moveSpeed *= 2;

            anim.SetTrigger("doDodge");
            isDodge = true;
            Invoke("DodgeOut", 0.5f);
        }
    }

    void DodgeOut()
    {
        moveSpeed *= 0.5f;
        isDodge = false;
    }

    void Interation()
    {
        if (iDown && nearObject != null && !isJump && !isDodge && !isDead)
        {
            if (nearObject.tag == "Weapon")
            {
                Item item = nearObject.GetComponent<Item>();
                int weaponIndex = item.value;
                hasWeapons[weaponIndex] = true;
                GameObject.Find("Canvas").transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(false);
                Destroy(nearObject);
            }
            // 상점 상호작용
            else if (nearObject.tag == "Shop")
            {
                Shop shop = nearObject.GetComponent<Shop>();
                // 인자값은 자신
                shop.Enter(this);
                isShop = true;
            }
        }
    }

    void Swap()
    {
        if (sDown1 && (!hasWeapons[0] || equipWeaponIndex == 0)) return;
        if (sDown2 && (!hasWeapons[1] || equipWeaponIndex == 1)) return;
        if (sDown3 && (!hasWeapons[2] || equipWeaponIndex == 2)) return;

        int weaponIndex = -1;
        if (sDown1) weaponIndex = 0;
        if (sDown2) weaponIndex = 1;
        if (sDown3) weaponIndex = 2;

        if ((sDown1 || sDown2 || sDown3) && !isJump && !isDodge && !isDead)
        {
            if (equipWeapon != null)
                equipWeapon.gameObject.SetActive(false);

            equipWeaponIndex = weaponIndex;
            equipWeapon = weapons[weaponIndex].GetComponent<Weapon>();
            equipWeapon.gameObject.SetActive(true);

            anim.SetTrigger("doSwap");
            isSwap = true;
            Invoke("SwapOut", 0.5f);
        }
    }    
    
    void SwapOut()
    {
        isSwap = false;
    }

    void Attack()
    {
        // 무기가 있을 때만 실행하도록 리턴
        if (equipWeapon == null) return;

        // 공격 딜레이에 시간을 더해주고 공격 가능 여부를 확인
        fireDelay += Time.deltaTime;
        isFireReady = equipWeapon.rate < fireDelay;

        if (fDown && isFireReady && !isDodge && !isSwap && !isShop && !isDead)
        {
            equipWeapon.Use();
            // 삼항 연산자를 이용하여 무기 타입에 따른 다른 트리거 실행
            anim.SetTrigger(equipWeapon.type == Weapon.Type.Melee ? "doSwing" : "doShot");
            // 공격 딜레이를 0으로 돌려서 다음 공격까지 기다리도록 작성
            fireDelay = 0;
        }
    }

    void Reload()
    {
        // 보유 무기가 없다면 탈출
        if (equipWeapon == null) return;
        // 근접 무기라면 탈출
        if (equipWeapon.type == Weapon.Type.Melee) return;
        // 총알이 없다면 탈출
        if (ammo == 0) return;

        if (rDown && !isJump && !isDodge && !isSwap && isFireReady && !isReload && !isShop && !isDead)
        {
            anim.SetTrigger("doReload");
            isReload = true;
            Invoke("ReloadOut", 0.5f);
        }
    }

    void Granade()
    {
        if (hasGranades == 0) return;

        if (gDown && !isReload && !isSwap && !isShop && !isDead)
        {
            // ScreenPointToRay() - 스크린에서 월드로 Ray를 쏘는 함수
            Ray ray = followCamera.ScreenPointToRay(Input.mousePosition);
            // RaycastHit 정보를 저장할 변수
            RaycastHit rayHit;
            // out : return처럼 반환값을 주어진 변수에 저장하는 키워드
            if (Physics.Raycast(ray, out rayHit, 100))
            {
                // RayCastHit의 마우스 클릭 위치 활용하여 회전을 구현
                Vector3 nextVec = rayHit.point - transform.position;
                // RayCastHit의 높이는 무시하도록 Y축 값을 0으로 초기화
                nextVec.y = 10;

                GameObject instantGranade = Instantiate(granadeObj, transform.position, transform.rotation);
                Rigidbody rbGranade = instantGranade.GetComponent<Rigidbody>();
                rbGranade.AddForce(nextVec, ForceMode.Impulse);
                rbGranade.AddTorque(Vector3.back * 10, ForceMode.Impulse);
                // 수류탄 1개 제거
                hasGranades--;
                // 배열의 첫 번째 배열을 비활성화
                granades[hasGranades].SetActive(false);
            }
        }
    }

    void FreezeRotation()
    {
        // angularVelocity - 물리 회전 속도
        rb.angularVelocity = Vector3.zero;
    }

    void StopToWall()
    {
        Debug.DrawRay(transform.position, transform.forward * 5, Color.green);
        // "Wall"이라는 레이어 마스크를 가진 오브젝트를 체크할 시 isBorder가 true가 됨.
        isBorder = Physics.Raycast(transform.position, transform.forward, 5, LayerMask.GetMask("Wall"));
    }

    void FixedUpdate()
    {
        FreezeRotation();
            StopToWall();
    }

    void ReloadOut()
    {
        // 플레이어가 소지한 탄을 고려해서 계산하기
        int reAmmo = ammo < equipWeapon.maxAmmo ? ammo : equipWeapon.maxAmmo;
        // 무기에 탄이 들어간다.
        equipWeapon.curAmmo = reAmmo;
        // 플레이어가 소지한 탄은 사라짐
        ammo -= reAmmo;
        isReload = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            anim.SetBool("isJump", false);
            isJump = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            Item item = other.GetComponent<Item>();
            switch (item.type)
            {
                // enum + switch
                case Item.Type.Ammo:
                    ammo += item.value;
                    if (ammo > maxAmmo)
                        ammo = maxAmmo;
                    break;
                case Item.Type.Coin:
                    coin += item.value;
                    if (coin > maxCoin)
                        coin = maxCoin;
                    break;
                case Item.Type.Heart:
                    health += item.value;
                    if (health > maxHealth)
                        health = maxHealth;
                    break;
                case Item.Type.Grenade:
                    // 수류단 개수대로 공전체가 활성화 되도록 구현
                    granades[hasGranades].SetActive(true);
                    hasGranades += item.value;
                    if (hasGranades > maxHasGranades)
                        hasGranades = maxHasGranades;
                    break;
            }
            Destroy(other.gameObject);
        }
        else if (other.tag == "EnemyBullet")
        {
            if (!isDamage)
            {
                Bullet enemyBullet = other.GetComponent<Bullet>();
                health -= enemyBullet.damage;

                // 보스의 근접공격 오브젝트의 이름으로 보스 공격을 인지
                bool isBossAtk = other.name == "Boss Melee Area";

                StartCoroutine(OnDamage(isBossAtk));
            }
            // RigidBody 유무를 조건으로 하여 Destroy() 호출
            if (other.GetComponent<Rigidbody>() != null) Destroy(other.gameObject);
        }
    }

    IEnumerator OnDamage(bool isBossAtk)
    {
        isDamage = true;
        foreach (MeshRenderer mesh in meshs) mesh.material.color = Color.yellow;

        if (isBossAtk) rb.AddForce(transform.forward * -25, ForceMode.Impulse);

        if (health <= 0 && !isDead) OnDie();

        // 1초간 무적 
        yield return new WaitForSeconds(1f);

        isDamage = false;
        foreach (MeshRenderer mesh in meshs) mesh.material.color = Color.white;

        if (isBossAtk) rb.velocity = Vector3.zero;
    }
    
    void OnDie()
    {
        anim.SetTrigger("doDie");
        isDead = true;
        manager.GameOver();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Weapon" || other.tag == "Shop")
        {
            nearObject = other.gameObject;
            GameObject.Find("Canvas").transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Weapon")
        {
            nearObject = null;
        }
        else if (other.tag == "Shop")
        {
            Shop shop = nearObject.GetComponent<Shop>();
            shop.Exit();
            isShop = false;
            nearObject = null;
            GameObject.Find("Canvas").transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(false);
        }
     }
}