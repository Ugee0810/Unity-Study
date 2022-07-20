using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    void Shoot(GameObject obj, GameObject player);
}

public class Bullet1 : MonoBehaviour, IWeapon // 2¹ßÂ¥¸® ÃÑ¾Ë
{
    public void Shoot(GameObject obj, GameObject player) // ÃÑ¾Ë ¹ß»ç
    {
        GameObject goBullet0 = obj;
        goBullet0.transform.position = transform.position;

        Rigidbody2D rigid = goBullet0.GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
    }
}
