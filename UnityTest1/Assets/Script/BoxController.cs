using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
    }

    public void OnCollisionEnter(Collision collision) // 접촉하면 이벤트 발생
    {
        print("충돌발생 Enter!");
    }    
    
    public void OnCollisionExit(Collision collision) // 떨어지면 이벤트 발생
    {
        print("충돌발생 Exit!");
    }


}
