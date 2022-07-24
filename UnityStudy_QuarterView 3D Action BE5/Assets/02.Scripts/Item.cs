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

    void Update()
    {
        // Rotate() 함수로 계속 회전하도록 효과 내기
        transform.Rotate(Vector3.up * 20 * Time.deltaTime);    
    }
}
