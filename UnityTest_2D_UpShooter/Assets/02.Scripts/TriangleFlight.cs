using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleFlight : Flight
{
    public TriangleFlight()
    {
        type = FlightType.Triangle;
        name = "Enemy1";
        health = 100;
        speed = 1;
        power = 10;
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void Move()
    {


        Rigidbody2D ownRd = gameObject.GetComponent<Rigidbody2D>();
        ownRd.velocity = new Vector2(0, speed * (-1));
    }

    public override void SetPlayer()
    {
        goOriginPlayer = goPlayer;
    }

    public override void Attack()
    {
        //
    }

    public override void OnHit(float playerBulletPower)
    {
        health -= playerBulletPower;
        spriteRenderer.sprite = sprites[1];
        Invoke("ReturnSprite", 0.1f);

        if (health <= 0)
        {
            Destroy(gameObject);
            //Player playerLogic = goPlayer.GetComponent<Player>();
            //playerLogic.nScore += nDmgPoint;
        }
    }

    public override void ReturnSprite()
    {
        spriteRenderer.sprite = sprites[0];
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "PlayerBullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            OnHit(bullet.power);

            Destroy(collision.gameObject);
        }
    }
}
