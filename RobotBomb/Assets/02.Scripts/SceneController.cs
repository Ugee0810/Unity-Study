using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    Animator animator;

    void Start() 
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            animator.SetBool("isDeath", false);
            SceneManager.LoadScene("MainScene");
        }
    }
}
