using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float levelStartDelay = 2f;
    // 캐릭터가 움직일 때 마다 몬스터도 움직임
    public float turnDelay = 0.1f;
    public int playerFoodPoints = 100;
    public static GameManager instance = null;

    [HideInInspector] public bool playersTurn = true; // 플레이어의 움직임 판단 여부

    private BoardManager boardManager;
    private int level = 1;
    private List<Enemy> enemies; // 생성된 Enemmy 관리용 리스트
    private bool enemiesMoving;

    void Awake()
    {
        // Singleton
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        enemies = new List<Enemy>();

        boardManager = GetComponent<BoardManager>();

        InitGame();
    }

    void InitGame() // 게임 초기화할 땐 Enemy리스트를 초기화해주고, 보드매니저의 레벨에 따라 재생성 하기 위해 재호출
    {
        enemies.Clear();

        boardManager.SetupScene(level);
    }

    public void AddEnemyToList(Enemy script)
    {
        enemies.Add(script);
    }
}
