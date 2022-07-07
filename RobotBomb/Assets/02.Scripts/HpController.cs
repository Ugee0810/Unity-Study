using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HpController : MonoBehaviour
{
    GameObject hp;

    void Start()
    {
        hp = GameObject.Find("HpImage");
    }

    void Update()
    {
        
    }

    public void HpControll()
    {
        // Image������Ʈ�� fillAmount ����
        hp.GetComponent<Image>().fillAmount -= 0.1f;

        if (hp.GetComponent<Image>().fillAmount <= 0)
        {
            // Death Animation ����

            //Scene ��ȯ
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
