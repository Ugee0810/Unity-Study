using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public float mvSpeed = 0.0f;
    public float roSpeed = 0.0f;

    public int playerNum = 1;  // ��ũ ��ȣ
    private string mvAxisName; // �̵��� �̸�(Vertical)
    private string roAxisName; // ȸ���� �̸�(Horizontal)

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
        // Input.GetAxis() - ��ǲŰ �Ҵ�(w, a, s, d)
        float mv = Input.GetAxis(mvAxisName) * mvSpeed * Time.deltaTime;
        float ro = Input.GetAxis(roAxisName) * roSpeed * Time.deltaTime;

        transform.Translate(0, 0, mv);
        transform.Rotate(0, ro, 0);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "SHELL") // �浹ü�� ��ź�̸�
        {
            atkCount++;

            if (atkCount == 3) // 3ȸ ��ź�� ���� ��
            {
                ParticleSystem fire = Instantiate(tankExplosion, transform.position, transform.rotation); // ���� ��ƼŬ ����
                fire.Play(); // ����Ʈ ���

                Destroy(gameObject);
                Destroy(fire, 3.0f);
            }
        }
    }
}
