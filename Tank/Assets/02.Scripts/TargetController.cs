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
        if (collision.collider.tag == "SHELL") // �浹ü�� ��ź�̸�
        {
            ParticleSystem fire = Instantiate(tankExplosion, transform.position, transform.rotation); // ���� �� ���� ��ƼŬ ����
            fire.Play(); // ����Ʈ ���

            Destroy(gameObject);
            Destroy(fire, 3.0f);
        }
    }
}
