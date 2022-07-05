using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed = 0.0f;

    void Start() { }
    void Update() { }

    public void Shoot()
    {
        GetComponent<Rigidbody>().AddForce(0, 0, bulletSpeed);
    }

    public void OnCollisionEnter(Collision collision)
    {
        // 총알이 ENEMY태그 오브젝트와 충돌 시 총알 제거
        if (collision.collider.tag == "ENEMY")
        {
            GameObject manager = GameObject.Find("ScoreManager");
            //manager.GetComponent<ScoreScript>().IncScore();
            manager.GetComponent<ScoreScript>().Target();

            Destroy(gameObject);
        }
    }
}
