using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    GameObject camera        = GameObject.Find("Camera");
    GameObject tankRenderers = GameObject.Find("TankRenderers");
    GameObject fireTransform = GameObject.Find("FireTransform");
    GameObject ui            = GameObject.Find("UI");

    public float mvSpeed = 0f;
    public float roSpeed = 0f;

    public int playerNum = 1;   // 탱크 번호
    private string mvAxisName;  // 이동축 이름(Vertical)
    private string roAxisName;  // 회전축 이름(Horizontal)
    private string RespawnName; // 리스폰 이름(Respawn)

    public ParticleSystem tankExplosion;
    private int atkCount = 0; // 피격 횟수

    public bool isDie = false; // 상태변수 사용 죽음 체크
    Vector3 originPos = new Vector3(); // 리스폰 위치 기억

    void Start()
    {
        mvAxisName  = "Vertical"   + playerNum;
        roAxisName  = "Horizontal" + playerNum;
        RespawnName = "Respawn"    + playerNum;

        isDie = false;
        originPos = transform.position;
    }

    void Update()
    {
        if (isDie == false)
        {
            /*
            camera.SetActive(true);
            tankRenderers.SetActive(true);
            fireTransform.SetActive(true);
            */

            // Input.GetAxis() - 인풋키 할당(w, a, s, d)
            float mv = Input.GetAxis(mvAxisName) * mvSpeed * Time.deltaTime;
            float ro = Input.GetAxis(roAxisName) * roSpeed * Time.deltaTime;

            transform.Translate(0, 0, mv);
            transform.Rotate(0, ro, 0);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "SHELL") // 충돌체가 포탄이면
        {
            atkCount++;

            // 포탄 3회 피격 시 게임 오버
            if (atkCount == 3) IsDie();
        }
    }

    void IsDie()
    {
        isDie = true;

        camera.SetActive(false);
        tankRenderers.SetActive(false);
        fireTransform.SetActive(false);
        ui.SetActive(true);

        ParticleSystem fire = Instantiate(tankExplosion, transform.position, transform.rotation); // 폭발 파티클 생성
        fire.Play(); // 이팩트 재생
        Destroy(fire, 3.0f);

        if (Input.GetButtonDown(RespawnName)) Respawn();
    }

    public void Respawn()
    {
        // 3회 포탄 맞은 거 리셋
        // 생존 상태 변수 체크
        // 원래 위치로 리셋
        atkCount = 0;
        isDie = false;
        ui.SetActive(false); // 리스폰 안내 UI 비활성화
        transform.position = originPos;
    }
}
