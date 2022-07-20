using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    MyBullet myBullet;

    void Start()
    {
        myBullet = new MyBullet();

        myBullet.SetWeapon(new Bullet1());
    }

    public void ChangeToBullet0() // �Ѿ� 1��
    {
        myBullet.SetWeapon(new Bullet0());
    }

    public void ChangeToBullet1() // �Ѿ� 2��
    {
        myBullet.SetWeapon(new Bullet1());
    }

    public void Fire()
    {
        myBullet.Shoot();
    }
}
