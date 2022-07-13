using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HpController : MonoBehaviour
{
    GameObject hp;

    Animator animator;

    void Start()
    {
        hp = GameObject.Find("HpImage");
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void HpControll()
    {
        // Image������Ʈ�� fillAmount ����
        hp.GetComponent<Image>().fillAmount -= 0.21f;

        if (hp.GetComponent<Image>().fillAmount <= 0)
        {
            // Death Animation ����
            animator.SetBool("isDeath", true);
            
            //Scene ��ȯ
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
