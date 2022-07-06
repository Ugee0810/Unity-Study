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
}
