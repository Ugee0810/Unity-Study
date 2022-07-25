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
            StartCoroutine(OnDamage(reactVec));
        }
        else if (collision.tag == "Bullet")
        {
            Bullet bullet = collision.GetComponent<Bullet>();
            curHelath -= bullet.damage;
            // 현재 위치에 피격 위치를 빼서 반작용 방향 구하기
            Vector3 reactVec = transform.position - collision.transform.position;
            // 충돌한 총알 삭제
            Destroy(collision.gameObject);
            StartCoroutine(OnDamage(reactVec));
        }
    }

    IEnumerator OnDamage(Vector3 reactVec)
    {
        mat.color = Color.red;
        yield return new WaitForSeconds(0.05f);

        if (curHelath > 0)
        {
            mat.color = Color.white;

            reactVec = reactVec.normalized;
            rb.AddForce(reactVec * 3, ForceMode.Impulse);
        }
        else // Died
        {
            mat.color = Color.gray;
            // 14번 레이어로 변경(Enemy Dead)
            gameObject.layer = 14;

            // 방향은 방향대로 밀려나는 값이 통일됨
            reactVec = reactVec.normalized;
            rb.AddForce(reactVec * 15, ForceMode.Impulse);      
            Destroy(gameObject, 4f);
        }
    }
}
