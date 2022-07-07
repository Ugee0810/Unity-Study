using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    Rigidbody2D robotRd;
    Animator animator;

    public float walkSpeed;
    public float jumpSpeed;

    private bool isMove;
    private bool isJumping;

    void Start()
    {
        robotRd  = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Debug를 통해 오브젝트의 x위치값을 확인하여, 화면에 나가지 않는 좌표 찾기
        // print("x : " + transform.position.x);

        // Mathf.Abs() - 유니티에서의 Math함수, 절대값 | velocity.x - 가속도 체크
        // float speedx = Mathf.Abs(robotRd.velocity.x);
        // print($"robotRd.velocity.x = {speedx}");

        //print($"isMove : {isMove}");
        //isMove = false;
        print($"isJumping : {isJumping}");

        // Robot Move ← 
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x >= -8.0f)
        {
            isMove = true;
            animator.SetBool("isWalk", true);
            transform.Translate(Vector2.left * walkSpeed * Time.deltaTime);
         // transform.localScale = new Vector2(x, y) - 좌우 반전(오브젝트의 크기만큼 빼거나 더함)
            transform.localScale = new Vector2(-2.0f, 2.0f);
        }

        // Robot Move →
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x <= 8.0f)
        {
            isMove = true;
            animator.SetBool("isWalk", true);
            transform.Translate(Vector2.right * walkSpeed * Time.deltaTime);
            transform.localScale = new Vector2(2.0f, 2.0f);
        }

        // Robot Stop Idle(속도를 이용해 싱크 조절)
        if (!isMove) animator.SetBool("isWalk", false);


        // Robot Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("jumpTrigger");
            robotRd.AddForce(transform.up * jumpSpeed, ForceMode2D.Impulse);
            isJumping = true;
            jumpSpeed = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
        jumpSpeed = 7;
    }
}