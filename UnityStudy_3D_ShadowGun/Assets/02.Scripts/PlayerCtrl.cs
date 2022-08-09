using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [Header("캐릭터 기본")]
    public float moveSpeed = 10;

    // 컴포넌트의 캐시 처리(미리 변수에 담아 두고 해당 변수에 접근하는 방식이 미세하지만 빠름)
    private Transform tr;

    private void Start()
    {
        // Transform 컴포넌트를 추출해 변수에 대입
        tr = GetComponent<Transform>();
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        tr.Translate(Vector3.forward * v * moveSpeed * Time.deltaTime);
    }
}
