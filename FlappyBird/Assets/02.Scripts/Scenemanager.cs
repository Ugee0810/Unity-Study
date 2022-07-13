using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanager : MonoBehaviour
{
    void Start()
    {
        SingletonManager.Instance.SetScore(77777);
    }

    void Update()
    {
        // [임시]스페이스바를 누르면 씬전환
        if (Input.GetAxis("Jump") == 1)
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
