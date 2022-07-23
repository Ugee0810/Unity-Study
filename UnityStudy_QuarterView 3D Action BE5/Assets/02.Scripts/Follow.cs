using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target; // Player 오브젝트의 위치 값 참조
    public Vector3   offset; // 위치 오프셋

    void Update()
    {
        transform.position = target.position + offset;
    }
}
