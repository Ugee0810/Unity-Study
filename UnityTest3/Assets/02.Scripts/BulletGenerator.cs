using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �Ѿ� ������ ���� ��ũ��Ʈ
public class BulletGenerator : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int time = 0;

    void Start() { }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // �������� �̿��� ������Ʈ(�Ѿ�) ����
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            // BulletController���� Shoot() �޼��� ȣ��(�Ѿ� �߻�)
            bullet.GetComponent<BulletController>().ShootToEnemy();

            DestroyObject(bullet, time);
        }
    }
}
