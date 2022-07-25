using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum Type
    {
        Ammo,
        Coin,
        Grenade,
        Heart,
        Weapon
    }

    // 아이템 종류와 값을 저장할 변수 선언
    public Type type;
    public int value;

    Rigidbody rb;
    SphereCollider sc;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        sc = GetComponent<SphereCollider>();
    }

    void Update()
    {
        // Rotate() 함수로 계속 회전하도록 효과 내기
        transform.Rotate(Vector3.up * 20 * Time.deltaTime);    
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            rb.isKinematic = true;
            // GetComponent() 함수는 중복일 때 가장 첫 번째 컴포넌트만 가져옴
            sc.enabled = false;
        }
    }
}
