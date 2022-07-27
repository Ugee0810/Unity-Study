using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 게임 매니저를 변수화하여 플레이어 접촉 시 스테이지 시작
public class StartZone : MonoBehaviour
{
    public GameManager manager;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") manager.StageStart();    
    }
}
