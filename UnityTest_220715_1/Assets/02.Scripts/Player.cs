using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 0f; // 변수 선언 할 때 초기화하는 게 좋다.

    void Start()
    {
        
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 curPos = transform.position; // 현 위치
        Vector2 nextPos = new Vector2(h, v); // 이동하는 위치

        transform.position = curPos + nextPos;
    }
}
