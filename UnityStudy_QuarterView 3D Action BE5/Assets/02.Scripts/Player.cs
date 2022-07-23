using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;

    float hAxis;
    float vAxis;

    Vector3 MoveVec;
    void Start()
    {
        
    }

    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        MoveVec = new Vector3(hAxis, 0, vAxis).normalized; // normalized - 어떤 방향이든 값이 1로 보정된 벡터(ft.대각선)
        transform.position += MoveVec * moveSpeed * Time.deltaTime;
    }
}
