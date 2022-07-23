using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;

    float hAxis;
    float vAxis;
    bool  wDown;
    Vector3 MoveVec;

    Animator anim;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>(); // GetComponentInChildren<>() - 자식 오브젝트에 있는 컴포넌트를 가져온다.
    }
    void Start()
    {
        
    }

    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        wDown = Input.GetButton("Walk"); // Input.GetButton() - 누를 때 적용 및 유지

        MoveVec = new Vector3(hAxis, 0, vAxis).normalized; // normalized - 어떤 방향이든 값이 1로 보정된 벡터(ft.대각선)

        // Move 구현
        transform.position += MoveVec * moveSpeed * Time.deltaTime;
        // Move - Walk 구현
        transform.position += MoveVec * moveSpeed * (wDown ? 0.3f : 1f) * Time.deltaTime;

        // Animation 구현
        anim.SetBool("isRun", MoveVec != Vector3.zero);
        anim.SetBool("isWalk", wDown);

        // Rotate 구현
        transform.LookAt(transform.position + MoveVec); // transform.LookAt() - 지정된 벡터를 향해서 회전시켜주는 함수
    }
}
