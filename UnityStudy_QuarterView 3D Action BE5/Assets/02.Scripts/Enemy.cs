using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHelath;
    public int curHelath;

    Rigidbody   rb;
    BoxCollider bc;
    Material   mat;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
        // Material을 가져오려면 아래의 구문처럼 한다.
        mat = GetComponent<MeshRenderer>().material;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Melee")
        {
            Weapon weapon = collision.GetComponent<Weapon>();
            curHelath -= weapon.damage;

            // 현재 위치에 피격 위치를 빼서 반작용 방향 구하기
            Vector3 reactVec = transform.position - collision.transform.position;

            StartCoroutine(OnDamage(reactVec, false));
        }
        else if (collision.tag == "Bullet")
        {
            Bullet bullet = collision.GetComponent<Bullet>();
            curHelath -= bullet.damage;

            // 현재 위치에 피격 위치를 빼서 반작용 방향 구하기
            Vector3 reactVec = transform.position - collision.transform.position;
            // 충돌한 총알 삭제
            Destroy(collision.gameObject);

            StartCoroutine(OnDamage(reactVec, false));
        }
    }

    public void HitByGrenade(Vector3 explosionPos)
    {
        curHelath -= 100;
        Vector3 reactVec = transform.position - explosionPos;
        StartCoroutine(OnDamage(reactVec, true));
    }

    IEnumerator OnDamage(Vector3 reactVec, bool isGrenade)
    {
        mat.color = Color.red;
        yield return new WaitForSeconds(0.05f);

        if (curHelath > 0)
        {
            mat.color = Color.white;
        }
        else // Died
        {
            mat.color = Color.gray;
            // 14번 레이어로 변경(Enemy Dead)
            gameObject.layer = 14;

            if (isGrenade)
            {
            // 방향은 방향대로 밀려나는 값이 통일됨
                reactVec = reactVec.normalized;
                reactVec += Vector3.up * 3;

                // 수류탄에 의한 사망 리액션은 큰 힘과 회전을 추가
                // RigidBody 속성의 X, Z로테이션을 체크 해제한다.
                rb.freezeRotation = false;
                rb.AddForce(reactVec * 5, ForceMode.Impulse);
                rb.AddTorque(reactVec * 20, ForceMode.Impulse);
            }
            else
            {
                reactVec = reactVec.normalized;
                reactVec += Vector3.up;
                rb.AddForce(reactVec * 5, ForceMode.Impulse);      
            }
            Destroy(gameObject, 4f);
        }
    }
}
