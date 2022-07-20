using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour, IWeapon // 2¹ßÂ¥¸® ÃÑ¾Ë
{
    public void Shoot(GameObject obj, GameObject player) // ÃÑ¾Ë ¹ß»ç
    {
        GameObject goBullet1 = Instantiate(obj);
        goBullet1.transform.position = player.transform.position;

        Rigidbody2D rigid = goBullet1.GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            Destroy(gameObject);
        }
    }
}
