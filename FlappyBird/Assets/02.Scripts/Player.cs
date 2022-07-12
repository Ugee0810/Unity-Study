using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * 200);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // tag를 쓰지 않고 충돌처리 방법

        if (collision.tag == "score")
        {
            // 점수 + 1
            // 게임 오브젝트를 찾는다.
            GameObject.FindObjectOfType<GameManager>().score++;
            Destroy(collision.gameObject);
        }
    }
}
