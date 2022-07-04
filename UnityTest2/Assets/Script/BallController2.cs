using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController2 : MonoBehaviour
{
    private Rigidbody ballRd;
    public float speed = 10.0f;

    Vector3 startPos;

    void Start()
    {
        ballRd = GetComponent<Rigidbody>();
        ballRd.AddForce(-speed, 0f, speed * 0.7f);

        startPos = new Vector3(0, 0, 0); // 위치 초기화
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) == true)    ballRd.AddForce(0f, 0f, +speed / 2);
        if (Input.GetKey(KeyCode.DownArrow) == true)  ballRd.AddForce(0f, 0f, -speed / 2);
        if (Input.GetKey(KeyCode.RightArrow) == true) ballRd.AddForce(+speed / 2, 0f, 0f);
        if (Input.GetKey(KeyCode.LeftArrow) == true)  ballRd.AddForce(-speed / 2, 0f, 0f);
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

            ballRd.AddForce(reflectVec * speed);
        }

        startPos = transform.position;
    }
}