using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonManager : MonoBehaviour
{
    private static SingletonManager instance = null;

    private int nScore = 0;

    private void Awake()
    {
      if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
      else
        {
            Destroy(this.gameObject);
        }
    }

    public static SingletonManager Instance
    {
        get 
        { 
            if (instance == null)
            {
                return null;
            }
            return instance;
        } 
    }

    public int GetScore()
    {
        return nScore;
    }

    public void SetScore(int num)
    {
        nScore = num;
    }
}
