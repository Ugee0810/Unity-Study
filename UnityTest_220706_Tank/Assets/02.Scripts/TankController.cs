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

    public int playerNum = 1;   // ��ũ ��ȣ
    private string mvAxisName;  // �̵��� �̸�(Vertical)
    private string roAxisName;  // ȸ���� �̸�(Horizontal)
    private string RespawnName; // ������ �̸�(Respawn)

    public ParticleSystem tankExplosion;
    private int atkCount = 0; // �ǰ� Ƚ��

    public bool isDie = false; // ���º��� ��� ���� üũ
    Vector3 originPos = new Vector3(); // ������ ��ġ ���

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

            // Input.GetAxis() - ��ǲŰ �Ҵ�(w, a, s, d)
            float mv = Input.GetAxis(mvAxisName) * mvSpeed * Time.deltaTime;
            float ro = Input.GetAxis(roAxisName) * roSpeed * Time.deltaTime;

            transform.Translate(0, 0, mv);
            transform.Rotate(0, ro, 0);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "SHELL") // �浹ü�� ��ź�̸�
        {
            atkCount++;

            // ��ź 3ȸ �ǰ� �� ���� ����
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

        ParticleSystem fire = Instantiate(tankExplosion, transform.position, transform.rotation); // ���� ��ƼŬ ����
        fire.Play(); // ����Ʈ ���
        Destroy(fire, 3.0f);

        if (Input.GetButtonDown(RespawnName)) Respawn();
    }

    public void Respawn()
    {
        // 3ȸ ��ź ���� �� ����
        // ���� ���� ���� üũ
        // ���� ��ġ�� ����
        atkCount = 0;
        isDie = false;
        ui.SetActive(false); // ������ �ȳ� UI ��Ȱ��ȭ
        transform.position = originPos;
    }
}
