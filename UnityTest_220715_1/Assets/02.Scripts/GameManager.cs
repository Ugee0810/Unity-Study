using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    private float curEnemySpawnDelay;
    private float maxEnemySpawnDelay;

    public Transform[]  spawnPoints;
    public GameObject[] enemyNumber;
    public Image[] imgLifes;

    void Update()
    {
        SpawnEnemy();
        ReloadEnemy();
    }

    /// <summary>
    /// Enemy 관련
    /// </summary>

    void ReloadEnemy()
    {
        curEnemySpawnDelay += Time.deltaTime;
    }

    void SpawnEnemy()
    {
        if (curEnemySpawnDelay < maxEnemySpawnDelay)
            return;

        int randPoint = Random.Range(0, 5);

        GameObject createEnemy = Instantiate(enemyNumber[Random.Range(0, 4)],
                                             spawnPoints[randPoint].position,
                                             spawnPoints[randPoint].rotation);

        Rigidbody2D rigidbody2D = createEnemy.GetComponent<Rigidbody2D>();
        Enemy enemy = createEnemy.GetComponent<Enemy>(); // Enemy의 speed 변수를 가져온다.
        rigidbody2D.velocity = Vector2.down * enemy.moveSpeed;
        enemy.player = player;


        maxEnemySpawnDelay = Random.Range(0.3f, 2.0f);
        curEnemySpawnDelay = 0f;
    }

    /// <summary>
    /// Player 관련
    /// </summary>

    public void GameOver()
    {

    }

    void AlivePlayer()
    {
        player.transform.position = Vector2.down * 4.0f;
        player.SetActive(true);
    }

    public void RespawnPlayer()
    {
        Invoke("AlivePlayer", 2.0f);
    }

    public void UpdateLifeIcon(int life)
    {
        for (int idx = 0; idx < 3; idx++)
        {
            imgLifes[idx].color = new Color(1, 1, 1, 0);
        }

        for (int idx = 0; idx < life; idx++)
        {
            imgLifes[idx].color = new Color(1, 1, 1, 0);
        }
    }
}
