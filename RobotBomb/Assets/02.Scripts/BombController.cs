using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    void Start() { }

    void Update() { }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hp = GameObject.Find("HpController"); // "HpController" - 오브젝트
        // 포탄이 로봇을 맞추면
        if (collision.gameObject.tag == "Robot") hp.GetComponent<HpController>().HpControll(); // HpController 스크립트의 메소드 호출

        Destroy(gameObject);
    }
}
