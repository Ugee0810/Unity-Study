using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{
    public Rigidbody  rb;
    public GameObject meshObj;
    public GameObject effectObj;

    void Start()
    {
        StartCoroutine(Explosion());
    }

    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(3f);

        // 물리 속도를 전부 0로 만든다.
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // 게임 오브젝트로 가져 온 이미지와 이펙트
        meshObj.SetActive(false);
        effectObj.SetActive(true);

        // 히트에 걸린 다수를 불러내기 위해 배열로 저장
        // SphereCastAll() - 구체 모양의 레이캐스팅(모든 물체)
        RaycastHit[] rayHits = Physics.SphereCastAll(transform.position,
                                                     15,
                                                     Vector3.up,
                                                     0f,
                                                     LayerMask.GetMask("Enemy"));
        // foreach문으로 수류탄 범위 적들의 피격 함수를 호출
        foreach (RaycastHit hitObj in rayHits)
        {
            hitObj.transform.GetComponent<Enemy>().HitByGrenade(transform.position);
        }
        Destroy(gameObject, 5f);
    }
}
