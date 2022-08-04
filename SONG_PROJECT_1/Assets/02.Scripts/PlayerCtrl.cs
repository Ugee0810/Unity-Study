using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public GameObject player;

    public float moveSpeed;

    float hAxis;
    float vAxis;
    bool  wDown; // °È±â

    Vector3 moveVec;

    private void Awake()
    {
        
    }

    private void Start()
    {
        moveSpeed = 3f;
    }

    private void Update()
    {
        GetInput();
            Move();
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        //wDown = Input.GetButton("Walk");
    }

    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        //this.transform.position += moveVec * moveSpeed * (wDown ? 0.3f : 1f) * Time.deltaTime;
        this.transform.position += moveVec * moveSpeed * Time.deltaTime;
    }
}
