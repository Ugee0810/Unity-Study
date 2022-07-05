using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun2Contoller : MonoBehaviour
{
    GameObject player;
    Vector3 dir;

    void Start()
    {
       player = GameObject.Find("Player");
    }

    void Update()
    {
        // 적의 총구를 플레이어 방향으로 조준하기 위해 로테이션 변경
        // ???와 enemy의 위치를 빼 주면 나를 가리키는 방향이 된다.
        dir = player.transform.position - this.transform.position;
        //Quaternion.LookRotation() - 오브젝트의 방향을 변경하는 메소드
        this.transform.rotation = Quaternion.LookRotation(dir);
    }
}
