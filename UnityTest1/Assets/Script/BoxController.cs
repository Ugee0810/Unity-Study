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

    public void OnCollisionEnter(Collision collision) // �����ϸ� �̺�Ʈ �߻�
    {
        print("�浹�߻� Enter!");
    }    
    
    public void OnCollisionExit(Collision collision) // �������� �̺�Ʈ �߻�
    {
        print("�浹�߻� Exit!");
    }


}
