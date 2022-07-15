using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 0f; // ���� ���� �� �� �ʱ�ȭ�ϴ� �� ����.

    void Start()
    {
        
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 curPos = transform.position; // �� ��ġ
        Vector2 nextPos = new Vector2(h, v); // �̵��ϴ� ��ġ

        transform.position = curPos + nextPos;
    }
}
