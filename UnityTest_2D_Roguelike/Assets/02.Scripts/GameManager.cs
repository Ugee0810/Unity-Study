using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private BoardManager boardManager;
    private int level = 1;

    void boardScript()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        InitGame();
    }

    private void InitGame()
    {
        boardScript.SetupScene(level);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
