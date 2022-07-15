using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 0f; // ���� ���� �� �� �ʱ�ȭ�ϴ� �� ����.
    public float bulletSpeed = 0f;
    public float curBulletDelay = 0f;
    public float maxBulletDealy;

    public GameObject playerBullet;

    public bool isTouchTop    = false;
    public bool isTouchBottom = false;
    public bool isTouchRight  = false;
    public bool isTouchLeft   = false;

    private Animator animator;

    void Start()
    {
        animator.GetComponent<Animator>(); // ������Ʈ�� ���� ���Ǵ� Start(), Awake()���� �ʱ�ȭ | Awake�� ��ü Scene�� �ε�� ��
    }

    void Update()
    {
        Move();
        Fire();
        ReloadBullet();
    }

    void Fire()
    {
        if (!Input.GetButton("Jump")) // Space
        {
            return;
        }

        if (curBulletDelay < maxBulletDealy)
            return;

        GameObject bullet = Instantiate(playerBullet, transform.position, Quaternion.identity);
        Rigidbody2D bulletRigidbody2D = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody2D.AddForce(Vector2.up * bulletSpeed, ForceMode2D.Impulse); // ForceMode2D.Impulse - ���� ��� ����(����x)

        curBulletDelay = 0f;
    }

    void ReloadBullet()
    {
        curBulletDelay += Time.deltaTime;
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if ((isTouchRight && h == 1) || (isTouchLeft && h == -1)) h = 0;

        float v = Input.GetAxisRaw("Vertical");
        if ((isTouchTop && v == 1) || (isTouchBottom && v == -1)) v = 0;

        Vector2 curPos = transform.position; // �� ��ġ
        Vector2 nextPos = new Vector2(h, v) * speed * Time.deltaTime; // �̵��ϴ� ��ġ

        transform.position = curPos + nextPos;
        
        if (Input.GetButtonDown("Horizontal") || Input.GetButtonUp("Horizontal"))
        {
            animator.SetInteger("Input", (int) h);
        }

        Debug.Log("Input : " + h);
        Debug.Log("Input : " + v);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    {
                        isTouchTop = true;
                    }
                    break;
                case "Bottom":
                    {
                        isTouchBottom = true;
                    }
                    break;
                case "Right":
                    {
                        isTouchRight = true;
                    }
                    break;
                case "Left":
                    {
                        isTouchLeft = true;
                    }
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    {
                        isTouchTop = false;
                    }
                    break;
                case "Bottom":
                    {
                        isTouchBottom = false;
                    }
                    break;
                case "Right":
                    {
                        isTouchRight = false;
                    }
                    break;
                case "Left":
                    {
                        isTouchLeft = false;
                    }
                    break;
            }
        }
    }
}
