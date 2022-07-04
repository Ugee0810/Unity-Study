using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    private Rigidbody playerRd;
    public float speed = 10.0f;


    // Start is called before the first frame update
    void Start()
    {
        // 해당 스크립트가 적용된 오브젝트에서 Rigidbody 컴포넌트 생성
        playerRd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            playerRd.AddForce(-speed, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            playerRd.AddForce(speed, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            playerRd.AddForce(0f, 0f, speed);
        }

        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            playerRd.AddForce(0f, 0f, -speed);
        }

        if (Input.GetKey(KeyCode.Space) == true)
        {
            playerRd.AddForce(0f, speed, 0f);
        }
    }
}
