using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject goGameManager;
    public ObjectManager objectManager;
    public GameObject goBullet;
    Animator anim;

    public int life = 0;
    public float moveSpeed = 0f;
    public float bulletSpeed = 0f;
    public int nScore;
    public float curBulletDelay = 0;
    public float maxBulletDelay;

    public bool isHit = false;
    public bool isControl;
    public bool[] joyControl;
    public bool isTouchTop = false;
    public bool isTouchBottom = false;
    public bool isTouchRight = false;
    public bool isTouchLeft = false;

    void Start()
    {
        anim = GetComponent<Animator>();
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

        GameObject bullet = objectManager.MakeObject("PlayerBullet");
        bullet.transform.position = transform.position;

        Rigidbody2D rd = bullet.GetComponent<Rigidbody2D>();
        rd.AddForce(Vector2.up * bulletSpeed, ForceMode2D.Impulse);

        curBulletDelay = 0;
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

        Vector2 curPos = transform.position;
        Vector2 nextPos = new Vector3(h, v) * moveSpeed * Time.deltaTime;

        transform.position = curPos + nextPos;

        if (Input.GetButtonDown("Horizontal") || Input.GetButtonUp("Horizontal"))
            anim.SetInteger("MoveDiretion", (int)h);
    }

    public void JoyPanel(int type)
    {
        for(int idx=0; idx<9; idx++)
            joyControl[idx] = idx == type;
    }

    public void JoyDown()
    {
        isControl = true;
    }

    public void JoyUp()
    {
        isControl = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            switch(collision.gameObject.name)
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

            GameManager gManager = goGameManager.GetComponent<GameManager>();

            gManager.UpdateLifeIcon(life);
            
            if (life == 0)
            {
                //gManager.GameOver();
            }
            else
            {
                gManager.RespawnPlayer();
            }
            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
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
