using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBallController : MonoBehaviour
{
    private Rigidbody bowlingBallRb;
    public float speed = 1.0f;
    Vector3 startPos;

    void Start()
    {
        bowlingBallRb = GetComponent<Rigidbody>();
        bowlingBallRb.AddForce(Random.Range(-400.0f, 400.0f), 0, speed);

        startPos = new Vector3(0, 0, 0); // 위치 초기화
    }

    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        // 공이 벽에 충돌하면
        if (collision.gameObject.CompareTag("WALL"))
        {
            // collision(wall)이라는 오브젝트의 3차원 포지션 값을 구한다.
            Vector3 currPos = transform.position;
            // 입사각
            Vector3 incomVec = currPos - startPos;
            // 수직 벡터
            Vector3 normalVec = collision.contacts[0].normal;
            // 반사각
            Vector3 reflectVec = Vector3.Reflect(incomVec, normalVec);
            // 반사각 정규화
            reflectVec = reflectVec.normalized;

            bowlingBallRb.AddForce(reflectVec * speed);
        }

        startPos = transform.position;
    }
}
