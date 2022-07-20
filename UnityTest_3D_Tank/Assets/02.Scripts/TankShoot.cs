using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShoot : MonoBehaviour
{
    public Rigidbody shellPrefab;
    public Transform fireTransform;

    public int playerNum = 1;
    public float shootSpeed = 0f;
    
    private string fireName;
    
    // Start is called before the first frame update
    void Start()
    {
        fireName = "Fire" + playerNum;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (Input.GetButtonDown(fireName))
        {
            // ��ź ������ ��ü ���� .. Instantiate(Rigidbody, Vector3.Position, Quaternion.Rotation)
            Rigidbody shellInstance = Instantiate(shellPrefab, fireTransform.position, fireTransform.rotation);
            // ��ź �߻�
            shellInstance.velocity = shootSpeed * fireTransform.forward;
        }
    }
}
