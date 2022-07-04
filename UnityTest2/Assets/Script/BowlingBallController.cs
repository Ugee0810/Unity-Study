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

        startPos = new Vector3(0, 0, 0); // ��ġ �ʱ�ȭ
    }

    void Update()
    {
        
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

            bowlingBallRb.AddForce(reflectVec * speed);
        }

        startPos = transform.position;
    }
}
