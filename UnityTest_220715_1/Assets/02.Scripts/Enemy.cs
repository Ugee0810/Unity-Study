using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public  float health;
    public  float moveSpeed;
    public  float bulletSpeed = 0;
    private float curBulletDelay = 0;
    public  float maxBulletDelay;

    public GameObject bulletEnemy;
    public GameObject player;

    public Sprite[] sprites; // 스프라이트 변수(피격 당할 때 이미지가 변해야 하므로 배열로 정의)
    SpriteRenderer spriteRenderer;

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
        if (curBulletDelay < maxBulletDelay) return;

        GameObject eBullet = Instantiate(bulletEnemy, transform.position, Quaternion.identity);
        Rigidbody2D rigidbody2D = eBullet.GetComponent<Rigidbody2D>();

        // Player를 유도하는 로직
        Vector2 dirVec = player.transform.position - transform.position;
        rigidbody2D.AddForce(dirVec.normalized * bulletSpeed, ForceMode2D.Impulse);

        curBulletDelay = 0;
    }

    void ReloadBullet()
    {
        curBulletDelay += Time.deltaTime;
    }

    void OnHit(float playerBulletPower)
    {
        spriteRenderer.sprite = sprites[1];
        Invoke("ReturnSprite", 0.1f); // startcoroutine으로도 해보자.

        health -= playerBulletPower;
        if (health <= 0) Destroy(gameObject);
    }

    void ReturnSprite()
    {
        spriteRenderer.sprite = sprites[0];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border") Destroy(gameObject);
        else if (collision.gameObject.tag == "PlayerBullet")
        {
            BulletPlayer bullet = collision.gameObject.GetComponent<BulletPlayer>();
            OnHit(bullet.hitPower);
        }
    }
}
