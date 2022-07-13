using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 direction;

    public void Shoot(Vector3 direction)
    {
        this.direction = direction;
        //Destroy(gameObject, 5.0f);
        Invoke("ReturnBulletToPolling", 5.0f); // 오브젝트를 풀링하므로 Destroy하면 안됨, Invoke로 5초마다 함수 반환
    }

    public void ReturnBulletToPolling()
    {
        ObjectPool.ReturnObject(this);
    }

    void Update()
    {
        transform.Translate(direction);
    }
}
