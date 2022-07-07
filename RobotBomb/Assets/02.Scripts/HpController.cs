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
        // Image오브젝트의 fillAmount 개념
        hp.GetComponent<Image>().fillAmount -= 0.1f;

        if (hp.GetComponent<Image>().fillAmount <= 0)
        {
            // Death Animation 실행

            //Scene 전환
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
