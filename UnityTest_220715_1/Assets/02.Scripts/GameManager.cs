using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public ObjectManager objManager;

    public GameObject goPlayer;
    //public GameObject[] goEnemies;
    public Image[] imgLifes;

    //public Text scoreText;
    //public GameObject goGameOver;

    public int spawnIdx = 0;
    public float curEnemySpawnDelay;
    public float nextEnemySpawnDelay;
    public bool spawnEnd;
    public Transform[] spawnPoints;
    public List<Spawn> spawnList;

    public string[] enemyNames = { "EnemyA",
                                   "EnemyB",
                                   "EnemyC",
                                   "EnemyD" };

    public class Spawn
    {
        public string type;  // 적기 타입
        public float  delay; // 나타나는 시간
        public int    point; // spawnpoint 중 하나
    };

    void Awake()
    {
        spawnList = new List<Spawn>();
        ReadSpawnFile();
    }

    void ReadSpawnFile()
    {
        spawnList.Clear();
        spawnIdx = 0;
        spawnEnd = false;

        TextAsset textFile = Resources.Load("stage") as TextAsset;
        StringReader stringReader = new StringReader(textFile.text);

        while (stringReader != null)
        {
            string txtLineData = stringReader.ReadLine();
            Debug.Log(txtLineData);
            if (txtLineData == null)
                break;

            Spawn data = new Spawn();
            data.type = txtLineData.Split(',')[0];
            data.delay = float.Parse(txtLineData.Split(',')[1]);
            data.point = int.Parse(txtLineData.Split(',')[2]);

            spawnList.Add(data);
        }
        stringReader.Close();

        nextEnemySpawnDelay = spawnList[1].delay;
    }

    private void Update()
    {
        curEnemySpawnDelay += Time.deltaTime;
        if (curEnemySpawnDelay > nextEnemySpawnDelay && !spawnEnd)
        {
            SpawnEnemy();
            curEnemySpawnDelay = 0;
        }

        Player playerLogic = goPlayer.GetComponent<Player>();
        //scoreText.text = string.Format("{0:n0}", playerLogic.nScore);
    }

    void SpawnEnemy()
    {
        int enemyIdx = 0;
        switch (spawnList[spawnIdx].type) // (0~4)
        {
            case "EnemyA":
                {
                    enemyIdx = 0;
                }
                break;
            case "EnemyB":
                {
                    enemyIdx = 1;
                }
                break;
            case "EnemyC":
                {
                    enemyIdx = 2;
                }
                break;
            case "EnemyD":
                {
                    enemyIdx = 3;
                }
                break;
        }

        int enemyPoint = spawnList[spawnIdx].point; // 0~4의 스폰 위치 변수 선언

        GameObject createEnemyA = objManager.MakeObject("EnemyA");
        createEnemyA.transform.position = spawnPoints[enemyPoint].position;
        Rigidbody2D rd = createEnemyA.GetComponent<Rigidbody2D>();
        Enemy enemy = createEnemyA.GetComponent<Enemy>();

        rd.velocity = new Vector2(0, enemy.moveSpeed * (-1));
        enemy.objManager = objManager;
        enemy.goPlayer = goPlayer;

        spawnIdx++;
        if (spawnIdx == spawnList.Count)
        {
            spawnEnd = true;
            return;
        }

        nextEnemySpawnDelay = spawnList[spawnIdx].delay;
    }

    public void RespawnPlayer()
    {
        Invoke("AlivePlayer", 1.0f);
    }

    void AlivePlayer()
    {
        goPlayer.transform.position = Vector3.down * 3.5f;
        goPlayer.SetActive(true);

        Player playerLogic = goPlayer.GetComponent<Player>();
        playerLogic.isHit = false;
    }

    public void UpdateLifeIcon(int life)
    {
        for (int idx = 0; idx < 3; idx++)
        {
            imgLifes[idx].color = new Color(1, 1, 1, 0);
        }

        for (int idx = 0; idx < life; idx++)
        {
            imgLifes[idx].color = new Color(1, 1, 1, 1);
        }
    }

    //public void GameOver()
    //{
    //    goGameOver.SetActive(true);
    //}

    //public void RetryGame()
    //{
    //    SceneManager.LoadScene(0);
    //}
}
