using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public  int   life = 0;
    public  float moveSpeed = 0f;
    public  float bulletSpeed = 0f;
    private float curBulletDelay = 0f;
    public  float maxBulletDelay;

    public GameObject bulletPlayer;
    public GameObject gameManager;

    public bool isHit = false;

    public bool[] joyControl;
    public bool   isControl;

    private bool isTouchTop    = false;
    private bool isTouchBottom = false;
    private bool isTouchRight  = false;
    private bool isTouchLeft   = false;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>(); // 컴포넌트에 대한 정의는 Start(), Awake()에서 초기화 | Awake는 전체 Scene이 로드될 때
    }

    void Update()
    {
        Move();
        Fire();
        ReloadBullet();
    }

    void Fire()
    {
        if (!Input.GetButton("Jump")) return;
        if (curBulletDelay < maxBulletDelay) return;

        GameObject pBullet = Instantiate(bulletPlayer, transform.position, Quaternion.identity);
        Rigidbody2D pBbulletRigidbody2D = pBullet.GetComponent<Rigidbody2D>();
        pBbulletRigidbody2D.AddForce(Vector2.up * bulletSpeed, ForceMode2D.Impulse); // ForceMode2D.Impulse - 질량 계산 무시(감속x)

        curBulletDelay = 0f;
    }

    void ReloadBullet()
    {
        curBulletDelay += Time.deltaTime;
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (joyControl[0]) { h = -1; v =  1; }
        if (joyControl[1]) { h =  0; v =  1; }
        if (joyControl[2]) { h =  1; v =  1; }
        if (joyControl[3]) { h = -1; v =  0; }
        if (joyControl[4]) { h =  0; v =  0; }
        if (joyControl[5]) { h =  1; v =  0; }
        if (joyControl[6]) { h = -1; v = -1; }
        if (joyControl[7]) { h =  0; v = -1; }
        if (joyControl[8]) { h =  1; v = -1; }

        if ((isTouchRight && h == 1) || (isTouchLeft && h == -1) || !isControl)
            h = 0;

        if ((isTouchTop && v == 1) || (isTouchBottom && v == -1) || !isControl)
            v = 0;

        Vector3 curPos = transform.position; // 현 위치
        Vector3 nextPos = new Vector3(h, v, 0) * moveSpeed * Time.deltaTime; // 이동 거리

        transform.position = curPos + nextPos;

        if (Input.GetButtonDown("Horizontal") || Input.GetButtonUp("Horizontal"))
        {
            anim.SetInteger("MoveDiretion", (int)h);
        }
    }

    public void JoyPanel(int type)
    {
        for (int idx = 0; idx < 9; idx++)
        {
            joyControl[idx] = idx == type;
        }
    }

    public void JoyDown()
    {
        isControl = true;
    }

    public void JoyUp()
    {
        isControl = false;
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
        else if (collision.gameObject.tag == "EnemyBullet")
        {
            if (isHit)
                return;

            isHit = true;

            life--;

            GameManager gManager = gameManager.GetComponent<GameManager>();

            gManager.UpdateLifeIcon(life);

            if (life == 0)
            {
                // GameOver()
            }
            else
            {
                gManager.RespawnPlayer();
            }
            gameObject.SetActive(false);
            Destroy(collision.gameObject);
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
