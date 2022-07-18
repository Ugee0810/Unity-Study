using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //public GameObject goBullet;
    public GameObject goPlayer;
    public ObjectManager objManager;
    //public Animator anim;

    public string enemyName;
    public float health;
    public float moveSpeed;
    public float bulletSpeed;
    //public int nDmgPoint;

    public float curBulletDelay = 0f;
    public float maxBulletDelay;

    public Sprite[] sprites;
    SpriteRenderer spriteRenderer;

    //public int patternIdx = 0;
    //public int curPatternCount = 0;
    //public int[] maxPatternCount = { 2, 3, 100, 10 };

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Fire();
        ReloadBullet();
    }

    void Fire()
    {
        if (curBulletDelay < maxBulletDelay)
            return;

        GameObject createBulletA = objManager.MakeObject("EnemyBulletA");
        createBulletA.transform.position = transform.position;

        Rigidbody2D rd = createBulletA.GetComponent<Rigidbody2D>();

        Vector3 dirVec = goPlayer.transform.position - transform.position;

        rd.AddForce(dirVec.normalized * bulletSpeed, ForceMode2D.Impulse);

        curBulletDelay = 0;
    }

    void ReloadBullet()
    {
        curBulletDelay += Time.deltaTime;
    }

    void ReturnSprite()
    {
        spriteRenderer.sprite = sprites[0];
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border" && enemyName != "EnemyBoss")
        {
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "Bullet_Player")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            OnHit(bullet.power);

            collision.gameObject.SetActive(false);
        }
    }

    void OnHit(float playerBulletPower)
    {
        health -= playerBulletPower;

        //if (name == "Boss")
        //{
        //    anim.SetTrigger("OnHit");
        //}
        spriteRenderer.sprite = sprites[1];

        Invoke("ReturnSprite", 0.1f);

        if (health <= 0)
        {
            gameObject.SetActive(false);

            //Player playerLogic = goPlayer.GetComponent<Player>();
            //playerLogic.nScore += nDmgPoint;
        }
    }

    void OnEnable()
    {
        switch (name)
        {
            case "EnemyA":
                {
                    health = 10;
                }
                break;
            case "EnemyB":
                {
                    health = 30;
                }
                break;
            case "EnemyC":
                {
                    health = 50;
                }
                break;
            case "EnemyD":
                {
                    health = 100;
                }
                break;
            case "EnemyBoss":
                {
                    health = 1000;
                    //Stop();
                }
                break;
        }
    }

    //void Stop()
    //{
    //    if (!gameObject.activeSelf)
    //        return;

    //    Rigidbody2D rigid = GetComponent<Rigidbody2D>();
    //    rigid.velocity = Vector2.zero;

    //    Invoke("Think", 2.0f);
    //}

    //void Think()
    //{
    //    patternIdx = patternIdx == 3 ? 0 : patternIdx + 1;

    //    curPatternCount = 0;

    //    switch (patternIdx)
    //    {
    //        case 0:
    //            FireFoward();
    //            break;
    //        case 1:
    //            FireShot();
    //            break;
    //        case 2:
    //            FireArc();
    //            break;
    //        case 3:
    //            FireAround();
    //            break;
    //    }
    //}

    //void FireFoward()
    //{
    //    curPatternCount++;
    //    if (curPatternCount < maxPatternCount[patternIdx])
    //        Invoke("FireFoward", 2.0f);
    //    else
    //        Invoke("Think", 3.0f);
    //}

    //void FireShot()
    //{

    //}

    //void FireArc()
    //{

    //}

    //void FireAround()
    //{

    //}
}
