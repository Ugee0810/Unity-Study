using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 0.0f; // 변수 선언 할 때 초기화하는 게 좋다.
    public bool isTouchTop    = false;
    public bool isTouchBottom = false;
    public bool isTouchRight  = false;
    public bool isTouchLeft   = false;
    Animator animator;

    void Start()
    {
        animator.GetComponent<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if ((isTouchRight && h == 1) || (isTouchLeft && h == -1))
        {
            h = 0;
        }

        float v = Input.GetAxisRaw("Vertical");
        if ((isTouchTop && v == 1) || (isTouchBottom && v == -1))
        {
            v = 0;
        }

        Vector2 curPos = transform.position; // 현 위치
        Vector2 nextPos = new Vector2(h, v); // 이동하는 위치

        transform.position = curPos + nextPos * speed * Time.deltaTime;

        if (h == 1)
        {
            animator.SetInteger(Input, 1);
        }
        else
        {
            animator.SetInteger(Input, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    {
                        isTouchTop = true;
                    }
                    break;
                case "Bottom":
                    {
                        isTouchBottom = true;
                    }
                    break;
                case "Right":
                    {
                        isTouchRight = true;
                    }
                    break;
                case "Left":
                    {
                        isTouchLeft = true;
                    }
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    {
                        isTouchTop = false;
                    }
                    break;
                case "Bottom":
                    {
                        isTouchBottom = false;
                    }
                    break;
                case "Right":
                    {
                        isTouchRight = false;
                    }
                    break;
                case "Left":
                    {
                        isTouchLeft = false;
                    }
                    break;
            }
        }
    }
}
