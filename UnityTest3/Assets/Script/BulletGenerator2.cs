using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 총알 프리팹 정의 스크립트
public class BulletGenerator2 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletTime = 0;
    public float time = 0;

    void Start() { }

    void Update()
    {
        //1초마다 실행
        this.time += Time.deltaTime;

        if (this.time > 1.0f)
        {
            Shoot();
            this.time = 0;
        }

        /*
        if (Input.GetMouseButtonDown(0))
        {
            // 프리팹을 이용해 오브젝트(총알) 생성
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            // BulletController에서 Shoot() 메서드 호출(총알 발사)
            bullet.GetComponent<BulletController>().ShootToPlayer();

            DestroyObject(bullet, bulletTime);
        }
        */
    }
    public void Shoot()
    {
        // 프리팹을 이용해 오브젝트(총알) 생성
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

        // BulletController에서 Shoot() 메서드 호출(총알 발사)
        bullet.GetComponent<BulletController>().ShootToPlayer();

        DestroyObject(bullet, bulletTime);
    }
}
