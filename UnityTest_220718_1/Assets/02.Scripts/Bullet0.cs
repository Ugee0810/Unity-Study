using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet0 : MonoBehaviour, IWeapon
{
    void Start()
    {
        
    }

    public void Shoot(GameObject obj, GameObject player) // ÃÑ¾Ë ¹ß»ç
    {
        GameObject goBullet0 = obj;
        goBullet0.transform.position = transform.position;

        Rigidbody2D rigid = goBullet0.GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
    }
}
