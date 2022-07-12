using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    //public float pipeSpeed;
    public GameObject objects;
    public TextMesh scoreText;

    void Start()
    {
        // CreateObjects() 메서드를 1초 후 호출, 2초 마다 재호출하는 메서드
        InvokeRepeating("CreateObjects", 1, 2);
    }

    public int Score
    {
        set
        {
            score = value;
            scoreText.text = Score.ToString();
        }
        get
        {
            return score;
        }
    }

    void Update()
    {
        // 주기별 콜 하는 방법

    }

    void CreateObjects()
    {
        Instantiate(objects, new Vector2(8f, Random.Range(0f, 2.5f)), Quaternion.identity);
    }
}
