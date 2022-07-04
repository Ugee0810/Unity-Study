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

        startPos = new Vector3(0, 0, 0); // ��ġ �ʱ�ȭ
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
        // ���� ���� �浹�ϸ�
        if (collision.gameObject.CompareTag("WALL"))
        {
            // collision(wall)�̶�� ������Ʈ�� 3���� ������ ���� ���Ѵ�.
            Vector3 currPos = transform.position;
            // �Ի簢
            Vector3 incomVec = currPos - startPos;
            // ���� ����
            Vector3 normalVec = collision.contacts[0].normal;
            // �ݻ簢
            Vector3 reflectVec = Vector3.Reflect(incomVec, normalVec);
            // �ݻ簢 ����ȭ
            reflectVec = reflectVec.normalized;

            ballRd.AddForce(reflectVec * speed);
        }

        startPos = transform.position;
    }
}