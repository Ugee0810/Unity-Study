using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShoot : MonoBehaviour
{
    public Rigidbody shellPrefab;
    public Transform fireTransform;
    public float shootSpeed = 0.0f;

    public int playerNum = 1;
    private string fireName;

    // Start is called before the first frame update
    void Start()
    {
        fireName = "Fire" + playerNum;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(fireName))
        {
            // Æ÷Åº ÇÁ¸®ÆÕ °´Ã¼ »ý¼º .. Instantiate(Rigidbody, Vector3.Position, Quaternion.Rotation)
            Rigidbody shellInstance = Instantiate(shellPrefab, fireTransform.position, fireTransform.rotation);
            // Æ÷Åº ¹ß»ç
            shellInstance.velocity = shootSpeed * fireTransform.forward;
        }
    }
}
