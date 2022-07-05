using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 총알 프리팹 정의 스크립트
public class BulletGenerator : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int time = 0;

    void Start() { }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 프리팹을 이용해 오브젝트(총알) 생성
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            // BulletController에서 Shoot() 메서드 호출(총알 발사)
            bullet.GetComponent<BulletController>().ShootToEnemy();

            DestroyObject(bullet, time);
        }
    }
}
