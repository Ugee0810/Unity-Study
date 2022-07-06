using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public float mvSpeed = 0.0f;
    public float roSpeed = 0.0f;

    public int playerNum = 1;  // 탱크 번호
    private string mvAxisName; // 이동축 이름(Vertical)
    private string roAxisName; // 회전축 이름(Horizontal)

    public ParticleSystem tankExplosion;
    private int atkCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        mvAxisName = "Vertical"   + playerNum;
        roAxisName = "Horizontal" + playerNum;
    }

    // Update is called once per frame
    void Update()
    {
        // Input.GetAxis() - 인풋키 할당(w, a, s, d)
        float mv = Input.GetAxis(mvAxisName) * mvSpeed * Time.deltaTime;
        float ro = Input.GetAxis(roAxisName) * roSpeed * Time.deltaTime;

        transform.Translate(0, 0, mv);
        transform.Rotate(0, ro, 0);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "SHELL") // 충돌체가 포탄이면
        {
            atkCount++;

            if (atkCount == 3) // 3회 포탄에 맞을 시
            {
                ParticleSystem fire = Instantiate(tankExplosion, transform.position, transform.rotation); // 폭발 파티클 생성
                fire.Play(); // 이팩트 재생

                Destroy(gameObject);
                Destroy(fire, 3.0f);
            }
        }
    }
}
