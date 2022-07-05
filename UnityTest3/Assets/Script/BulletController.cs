using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed = 0.0f;
    GameObject player;

    void Start() 
    {
    
    }

    void Update() 
    { 

    }
  
    public void ShootToEnemy()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, bulletSpeed));
    }  // 플레이어 -> 적
  
    public void ShootToPlayer()
    {
        player = GameObject.Find("Player");
        Vector3 dir = player.transform.position - this.transform.position;
        this.transform.rotation = Quaternion.LookRotation(dir);

        GetComponent<Rigidbody>().AddForce(dir * bulletSpeed / 5);
    }  // 적 -> 플레이어

    public void OnCollisionEnter(Collision collision)
    {
        // 총알이 ENEMY태그 오브젝트와 충돌 시 총알 제거
        if (collision.collider.tag == "ENEMY")
        {
            GameObject manager = GameObject.Find("ScoreManager");
            manager.GetComponent<ScoreScript>().IncScore();
            //manager.GetComponent<ScoreScript>().Target();

            Destroy(gameObject);
        }
    }
}
