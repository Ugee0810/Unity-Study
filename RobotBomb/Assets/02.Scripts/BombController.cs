using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    void Start() { }

    void Update() { }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hp = GameObject.Find("HpController"); // "HpController" - ������Ʈ
        // ��ź�� �κ��� ���߸�
        if (collision.gameObject.tag == "Robot") hp.GetComponent<HpController>().HpControll(); // HpController ��ũ��Ʈ�� �޼ҵ� ȣ��

        Destroy(gameObject);
    }
}
