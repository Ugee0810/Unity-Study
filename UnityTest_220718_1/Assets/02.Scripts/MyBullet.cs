using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBullet // ��ԵǴ� �Ѿ�
{
    private IWeapon weapon;

    public void SetWeapon (IWeapon weapon)
    {
        this.weapon = weapon;
    }

    public void Shoot()
    {
        weapon.Shoot();
    }
}
