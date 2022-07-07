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
        // Image오브젝트의 fillAmount 개념
        hp.GetComponent<Image>().fillAmount -= 0.21f;

        if (hp.GetComponent<Image>().fillAmount <= 0)
        {
            // Death Animation 실행
            animator.SetBool("isDeath", true);
            
            //Scene 전환
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
