using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public bool isMelee;
    public bool isRock;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor" && !isRock) Destroy(gameObject, 3f);
    }

    void OnTriggerEnter(Collider collision)
    {
        // 근접 공격 범위가 파괴되지 않도록 조건 추가(!isMelee)
        if (!isMelee && collision.gameObject.tag == "Wall") Destroy(gameObject);
    }
}
