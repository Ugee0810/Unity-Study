using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene : MonoBehaviour
{
    public TextMesh txtResult;
    void Start()
    {
        int nScore = SingletonManager.Instance.GetScore();
        txtResult.text = nScore.ToString();
    }

    void Update()
    {
        
    }
}
