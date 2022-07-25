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

    public int ammo;
    public int coin;
    public int health;

    public int maxAmmo;
    public int maxCoin;
    public int maxHealth;
    public int maxHasGranades;

    float hAxis;
    float vAxis;
    bool  wDown;
    bool  jDown;
    bool  fDown;
    bool  iDown;
    // 무기 교체
    bool sDown1;
    bool sDown2;
    bool sDown3;

    bool isJump;
    bool isDodge;
    bool isSwap;
    bool isFireReady = true;

    Vector3 moveVec;
    Vector3 dodgeVec;

    Animator anim;
    Rigidbody rb;

    // 트리거 된 아이템을 저장하기 위한 변수
    GameObject nearObject;
    // 기존에 장착된 무기를 저장하는 변수
    Weapon equipWeapon;
    int equipWeaponIndex = -1;
    // 공격 준비 딜레이 변수
    float fireDelay;

    void Awake()
    {
        // GetComponentInChildren<>() - 자식 오브젝트에 있는 컴포넌트를 가져온다.
        anim = GetComponentInChildren<Animator>();
        rb   = GetComponent<Rigidbody>();
    }

    void Update()
    {
          GetInput();
              Move();
              Jump();
             Dodge();
        Interation();
              Swap();
            Attack();
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        // Input.GetButton() - 누를 때 적용 및 유지
        wDown = Input.GetButton("Walk");
        jDown = Input.GetButtonDown("Jump");
        fDown = Input.GetButtonDown("Fire1");
        iDown = Input.GetButtonDown("Interation");
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
        // transform.LookAt() - 지정된 벡터를 향해서 회전시켜주는 함수
        transform.LookAt(transform.position + moveVec);
        // 스왑 중이거나 공격 중일 땐 움직이지 않도록 구현
        if (isSwap || !isFireReady) moveVec = Vector3.zero;
        // Move | 삼항연산자로 Walk 컨트롤
        transform.position += moveVec * moveSpeed * (wDown ? 0.3f : 1f) * Time.deltaTime;
        // Animation
        anim.SetBool("isRun", moveVec != Vector3.zero);
        anim.SetBool("isWalk", wDown);
    }

    void Jump()
    {
        // jDown && 정지 상태 && 점프 중 아닐 때 && 회피 중 아닐 때
        if (jDown && moveVec == Vector3.zero && !isJump && !isDodge)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);

            anim.SetTrigger("doJump");
            anim.SetBool("isJump", true);
            isJump = true;
        }
    }

    void Dodge()
    {
        if (jDown && moveVec != Vector3.zero && !isJump && !isDodge && !isSwap)
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
        if (iDown && nearObject != null && !isJump && !isDodge)
        {
            if (nearObject.tag == "Weapon")
            {
                Item item = nearObject.GetComponent<Item>();
                int weaponIndex = item.value;
                hasWeapons[weaponIndex] = true;

                Destroy(nearObject);
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

        if ((sDown1 || sDown2 || sDown3) && !isJump && !isDodge)
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

        if (fDown && isFireReady && !isDodge && !isSwap)
        {
            equipWeapon.Use();
            // 삼항 연산자를 이용하여 무기 타입에 따른 다른 트리거 실행
            anim.SetTrigger(equipWeapon.type == Weapon.Type.Melee ? "doSwing" : "doShot");
            // 공격 딜레이를 0으로 돌려서 다음 공격까지 기다리도록 작성
            fireDelay = 0;
        }
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
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Weapon")
            nearObject = other.gameObject;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Weapon")
            nearObject = null;
     }
}