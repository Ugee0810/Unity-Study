using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    // 공전 목표
    public Transform target;
    // 공전 속도
    public float orbitSpeed;
    // 목표와의 거리
    Vector3 offset;

    void Start()
    {
        // 플레이어와 수류탄의 사이 값
        offset = transform.position - target.position;
    }

    void Update()
    {
        transform.position = target.position + offset;

        // RotateAround() - 타겟 주위를 회전하는 함수
        transform.RotateAround(target.position, 
                               Vector3.up,
                               orbitSpeed * Time.deltaTime);

        // 함수 호출 후의 위치를 가지고 목표와의 거리를 유지
        offset = transform.position - target.position;
    }
}
