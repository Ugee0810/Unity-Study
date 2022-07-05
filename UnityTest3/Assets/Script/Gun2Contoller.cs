using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun2Contoller : MonoBehaviour
{
    GameObject player;
    Vector3 dir;

    void Start()
    {
       player = GameObject.Find("Player");
    }

    void Update()
    {
        // ���� �ѱ��� �÷��̾� �������� �����ϱ� ���� �����̼� ����
        // ???�� enemy�� ��ġ�� �� �ָ� ���� ����Ű�� ������ �ȴ�.
        dir = player.transform.position - this.transform.position;
        //Quaternion.LookRotation() - ������Ʈ�� ������ �����ϴ� �޼ҵ�
        this.transform.rotation = Quaternion.LookRotation(dir);
    }
}
