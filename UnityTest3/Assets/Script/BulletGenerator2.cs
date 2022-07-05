using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �Ѿ� ������ ���� ��ũ��Ʈ
public class BulletGenerator2 : MonoBehaviour
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
            bullet.GetComponent<BulletController>().ShootToPlayer();

            DestroyObject(bullet, time);
        }
    }
}
