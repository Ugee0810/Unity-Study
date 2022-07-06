using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController : MonoBehaviour
{
    public ParticleSystem shellExplosion;

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
        ParticleSystem fire = Instantiate(shellExplosion, transform.position, transform.rotation); // ���� �� ���� ��ƼŬ ����
        fire.Play(); // ����Ʈ ���

        Destroy(gameObject);
        Destroy(fire, 3.0f);
    }
}
