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
        //startPos = new Vector3(0, 0, 0); // ��ġ �ʱ�ȭ
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
        // ���� ���� �浹�ϸ�
        if (collision.gameObject.CompareTag("BALL"))
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
            
            collision.gameObject.GetComponent<> AddForce(reflectVec * speed);
        }

        startPos = transform.position;
    }
    */
}
