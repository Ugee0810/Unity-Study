using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    Rigidbody2D robotRd;
    Animator animator;

    public float walkSpeed;
    public float walkSpeedMax;
    private int moveCount;

    void Start()
    {
        robotRd  = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Debug�� ���� ������Ʈ�� x��ġ���� Ȯ���Ͽ�, ȭ�鿡 ������ �ʴ� ��ǥ ã��
        // print("x : " + transform.position.x);

        // Mathf.Abs() - ����Ƽ������ Math�Լ�, ���밪 | velocity.x - ���ӵ� üũ
        // float speedx = Mathf.Abs(robotRd.velocity.x);
        // print($"robotRd.velocity.x = {speedx}");

        print($"moveCount : {moveCount}");

        moveCount = 0;

        // Robot Move ��
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x >= -8.0f)
        {
            moveCount++;
            animator.SetBool("isWalking", true);
            transform.Translate(Vector2.left * walkSpeed * Time.deltaTime);
            // transform.localScale = new Vector2(x, y) - �¿� ����(������Ʈ�� ũ�⸸ŭ ���ų� ����)
            transform.localScale = new Vector2(-2.0f, 2.0f);
        }

        // Robot Move ��
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x <= 8.0f)
        {
            moveCount++;
            animator.SetBool("isWalking", true);
            transform.Translate(Vector2.right * walkSpeed * Time.deltaTime);
            transform.localScale = new Vector2(2.0f, 2.0f);
        }

        // Robot Stop Idle(�ӵ��� �̿��� ��ũ ����)
        if (moveCount == 0)
        {
            animator.SetBool("isWalking", false);
        }
    }
}