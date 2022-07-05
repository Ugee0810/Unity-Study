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
        // �Ѿ��� ENEMY�±� ������Ʈ�� �浹 �� �Ѿ� ����
        if (collision.collider.tag == "ENEMY")
        {
            GameObject manager = GameObject.Find("ScoreManager");
            //manager.GetComponent<ScoreScript>().IncScore();
            manager.GetComponent<ScoreScript>().Target();

            Destroy(gameObject);
        }
    }
}
