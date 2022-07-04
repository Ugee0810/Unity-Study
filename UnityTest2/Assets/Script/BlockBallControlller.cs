using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBallControlller : MonoBehaviour
{
    private Rigidbody ballRb;
    public float speed = 0.0f;
    Vector3 startPos;

    void Start()
    {
        ballRb = GetComponent<Rigidbody>();
        ballRb.AddForce(Random.Range(-500.0f, 500.0f), 0f, speed * 0.7f);

        startPos = new Vector3(0, 0, 0); // ��ġ �ʱ�ȭ
    }

    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        // ���� ���� �浹�ϸ�
        if (collision.gameObject.CompareTag("WALL") || collision.gameObject.CompareTag("RACKET"))
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

            ballRb.AddForce(reflectVec * speed);
        }

        if (collision.gameObject.CompareTag("BLOCK"))
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

            ballRb.AddForce(reflectVec * speed);

            // �ش� �� ������Ʈ ����
            Destroy(collision.gameObject);
        }
        startPos = transform.position;
    }
}
