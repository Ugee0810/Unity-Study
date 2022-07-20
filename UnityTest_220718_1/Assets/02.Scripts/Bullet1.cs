using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    void Shoot(GameObject obj, GameObject player);
}

public class Bullet1 : MonoBehaviour, IWeapon // 2��¥�� �Ѿ�
{
    public void Shoot(GameObject obj, GameObject player) // �Ѿ� �߻�
    {
        GameObject goBullet1 = Instantiate(obj);
        goBullet1.transform.position = player.transform.position;

        Rigidbody2D rigid = goBullet1.GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
    }
}
