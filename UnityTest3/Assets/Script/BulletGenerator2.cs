using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �Ѿ� ������ ���� ��ũ��Ʈ
public class BulletGenerator2 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletTime = 0;
    public float time = 0;

    void Start() { }

    void Update()
    {
        //1�ʸ��� ����
        this.time += Time.deltaTime;

        if (this.time > 1.0f)
        {
            Shoot();
            this.time = 0;
        }

        /*
        if (Input.GetMouseButtonDown(0))
        {
            // �������� �̿��� ������Ʈ(�Ѿ�) ����
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            // BulletController���� Shoot() �޼��� ȣ��(�Ѿ� �߻�)
            bullet.GetComponent<BulletController>().ShootToPlayer();

            DestroyObject(bullet, bulletTime);
        }
        */
    }
    public void Shoot()
    {
        // �������� �̿��� ������Ʈ(�Ѿ�) ����
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

        // BulletController���� Shoot() �޼��� ȣ��(�Ѿ� �߻�)
        bullet.GetComponent<BulletController>().ShootToPlayer();

        DestroyObject(bullet, bulletTime);
    }
}
