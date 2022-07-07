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

    void Start()
    {
        robotRd  = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Debug�� ���� ������Ʈ�� x��ġ���� Ȯ���Ͽ�, ȭ�鿡 ������ �ʴ� ��ǥ ã��
        print("x : " + transform.position.x);

        // Mathf.Abs() - ����Ƽ������ Math�Լ�, ���밪 | velocity.x - ���ӵ� üũ
        // float speedx = Mathf.Abs(robotRd.velocity.x);
        // print($"robotRd.velocity.x = {speedx}");

        // print($"isMove : {isMove}");
        isMove = false;

        // Robot Move �� 
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x >= -11.5f)
        {
            isMove = true;
            animator.SetBool("isWalk", true);
            transform.Translate(Vector2.left * walkSpeed * Time.deltaTime);
         // transform.localScale = new Vector2(x, y) - �¿� ����(������Ʈ�� ũ�⸸ŭ ���ų� ����)
            transform.localScale = new Vector2(-2.0f, 2.0f);
        }

        // Robot Move ��
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x <= 11.5f)
        {
            isMove = true;
            animator.SetBool("isWalk", true);
            transform.Translate(Vector2.right * walkSpeed * Time.deltaTime);
            transform.localScale = new Vector2(2.0f, 2.0f);
        }

        // Robot Walk Animation Stop
        if (!isMove) animator.SetBool("isWalk", false); 
        
        // Robot Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            robotRd.AddForce(transform.up * jumpSpeed, ForceMode2D.Impulse);
            animator.SetBool("isJump", true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
            animator.SetBool("isJump", false); 
    }
}