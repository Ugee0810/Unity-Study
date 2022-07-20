using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public ParticleSystem tankExplosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "SHELL") // 충돌체가 포탄이면
        {
            ParticleSystem fire = Instantiate(tankExplosion, transform.position, transform.rotation); // 접촉 시 폭발 파티클 생성
            fire.Play(); // 이팩트 재생

            Destroy(gameObject);
            Destroy(fire, 3.0f);
        }
    }
}
