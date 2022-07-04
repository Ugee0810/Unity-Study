using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketController : MonoBehaviour
{
    private Rigidbody racketRd;
    public float speed = 0.0f;
    //Vector3 startPos;

    void Start()
    {
        racketRd = GetComponent<Rigidbody>();
        //startPos = new Vector3(0, 0, 0); // 위치 초기화
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) == true) racketRd.AddForce(speed, 0, 0);
        if (Input.GetKey(KeyCode.LeftArrow) == true)  racketRd.AddForce(-speed, 0, 0);
        //if (Input.GetKey(KeyCode.RightArrow) == true) transform.Translate(Vector3.right * speed * Time.deltaTime);
        //if (Input.GetKey(KeyCode.LeftArrow)  == true) transform.Translate(Vector3.left  * speed * Time.deltaTime);
    }

    /*
    public void OnCollisionEnter(Collision collision)
    {
        // 공이 벽에 충돌하면
        if (collision.gameObject.CompareTag("BALL"))
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
            
            collision.gameObject.GetComponent<> AddForce(reflectVec * speed);
        }

        startPos = transform.position;
    }
    */
}
