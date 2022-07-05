using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private Text score;
    
    private int count;

    void Start()
    {
        score = GameObject.Find("Score").GetComponent<Text>();
        count = 0;
    }

    void Update()
    {
        
    }

    public void IncScore()
    {
        count++;
        score.text = count.ToString();
    }    
}
