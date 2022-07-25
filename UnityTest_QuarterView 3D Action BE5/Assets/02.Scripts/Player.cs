using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float jumpPower;

    float hAxis;
    float vAxis;
    bool  wDown;
    bool  jDown;

    bool isJump;
    bool isDodge;

    Vector3 moveVec;
    Vector3 dodgeVec;

    Animator anim;
    Rigidbody rb;

    void Awake()
    {
        // GetComponentInChildren<>() - 자식 오브젝트에 있는 컴포넌트를 가져온다.
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        GetInput();
            Move();
            Jump();
           Dodge(); 
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        // Input.GetButton() - 누를 때 적용 및 유지
        wDown = Input.GetButton("Walk");
        jDown = Input.GetButtonDown("Jump");
    }

    void Move()
    {
        // normalized - 어떤 방향이든 값이 1로 보정된 벡터(ft.대각선)
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;
        // transform.LookAt() - 지정된 벡터를 향해서 회전시켜주는 함수
        transform.LookAt(transform.position + moveVec);
        // 회피 중에는 움직임 벡터 -> 회피 방향 벡터로 바뀌도록 구현
        if (isDodge) moveVec = dodgeVec;
        // Move
        transform.position += moveVec * moveSpeed * Time.deltaTime;
        // Move - Walk
        transform.position += moveVec * moveSpeed * (wDown ? 0.3f : 1f) * Time.deltaTime;
        // Animation 구현
        anim.SetBool("isRun", moveVec != Vector3.zero);
        anim.SetBool("isWalk", wDown);
    }

    void Jump()
    {
        if (jDown && moveVec == Vector3.zero && !isJump && !isDodge)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            anim.SetBool("isJump", true);
            anim.SetTrigger("doJump");
            isJump = true;
        }
    }

    void Dodge()
    {
        if (jDown && moveVec != Vector3.zero && !isJump && !isDodge)
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


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            anim.SetBool("isJump", false);
            isJump = false;
        }
    }
}
