using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    void Shoot(GameObject obj, GameObject player);
}

public enum WeaponType // 총알 타입 정의
{
    Bullet0,
    Bullet1
}

public class WeaponManager : MonoBehaviour
{
    public GameObject bullet0;
    public GameObject bullet1;

    private GameObject myBullet;

    private IWeapon weapon;

    private void SetWeaponType (WeaponType weaponType)
    {
        Component c = gameObject.GetComponent<IWeapon>() as Component;
        if (c != null)
        {
            Destroy(c);
        }

        switch(weaponType)
        {
            case WeaponType.Bullet0:
                {
                    weapon = gameObject.AddComponent<Bullet0>();
                    myBullet = bullet0;
                }
                break;
            case WeaponType.Bullet1:
                {
                    weapon = gameObject.AddComponent<Bullet1>();
                    myBullet = bullet1;
                }
                break;
        }
    }

    void Start()
    {
        SetWeaponType(WeaponType.Bullet0); // 처음 무기 상태 초기화
    }

    public void ChangeToBullet0() // 총알 1발
    {
        SetWeaponType(WeaponType.Bullet0);
    }

    public void ChangeToBullet1() // 총알 2발
    {
        SetWeaponType(WeaponType.Bullet1);
    }

    public void Fire(GameObject player)
    {
        weapon.Shoot(myBullet, player);
    }
}
