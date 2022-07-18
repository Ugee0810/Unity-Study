using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    GameObject[] goTargetPool;

    GameObject[] goEnemyA;
    GameObject[] goEnemyB;
    GameObject[] goEnemyC;
    GameObject[] goEnemyD;

    GameObject[] goBulletEnemyA;
    GameObject[] goBulletEnemyB;
    GameObject[] goBulletEnemyC;
    GameObject[] goBulletEnemyD;

    GameObject[] goBulletPlayer;

    public GameObject enemyAPrefab;
    public GameObject enemyBPrefab;
    public GameObject enemyCPrefab;
    public GameObject enemyDPrefab;

    public GameObject bulletEnemyAPrefab;
    public GameObject bulletEnemyBPrefab;
    public GameObject bulletEnemyCPrefab;
    public GameObject bulletEnemyDPrefab;

    public GameObject bulletPlayer;

    void Start()
    {
        goEnemyA = new GameObject[10];
        goEnemyB = new GameObject[10];
        goEnemyC = new GameObject[10];
        goEnemyD = new GameObject[10];

        goBulletEnemyA = new GameObject[100];
        goBulletEnemyB = new GameObject[100];
        goBulletEnemyC = new GameObject[100];
        goBulletEnemyD = new GameObject[100];

        goBulletPlayer = new GameObject[100];

        Generate();
    }

    void Generate()
    {
        for (int i = 0; i < goEnemyA.Length; i++)
        {
            goEnemyA[i] = Instantiate(enemyAPrefab);
            goEnemyA[i].SetActive(false);
        }
        for (int i = 0; i < goEnemyB.Length; i++)
        {
            goEnemyB[i] = Instantiate(enemyBPrefab);
            goEnemyB[i].SetActive(false);
        }
        for (int i = 0; i < goEnemyC.Length; i++)
        {
            goEnemyC[i] = Instantiate(enemyCPrefab);
            goEnemyC[i].SetActive(false);
        }
        for (int i = 0; i < goEnemyD.Length; i++)
        {
            goEnemyD[i] = Instantiate(enemyDPrefab);
            goEnemyD[i].SetActive(false);
        }


        for (int i = 0; i < goBulletEnemyA.Length; i++)
        {
            goBulletEnemyA[i] = Instantiate(bulletEnemyAPrefab);
            goBulletEnemyA[i].SetActive(false);
        }
        for (int i = 0; i < goBulletEnemyB.Length; i++)
        {
            goBulletEnemyB[i] = Instantiate(bulletEnemyBPrefab);
            goBulletEnemyB[i].SetActive(false);
        }
        for (int i = 0; i < goBulletEnemyC.Length; i++)
        {
            goBulletEnemyC[i] = Instantiate(bulletEnemyCPrefab);
            goBulletEnemyC[i].SetActive(false);
        }
        for (int i = 0; i < goBulletEnemyD.Length; i++)
        {
            goBulletEnemyD[i] = Instantiate(bulletEnemyDPrefab);
            goBulletEnemyD[i].SetActive(false);
        }


        for (int i = 0; i < goBulletPlayer.Length; i++)
        {
            goBulletPlayer[i] = Instantiate(bulletPlayer);
            goBulletPlayer[i].SetActive(false);
        }
    }

    public GameObject MakeObject(string objType)
    {
        switch (objType)
        {
            case "EnemyA":
                {
                    goTargetPool = goEnemyA;
                }
                break;
            case "EnemyB":
                {
                    goTargetPool = goEnemyB;
                }
                break;
            case "EnemyC":
                {
                    goTargetPool = goEnemyC;
                }
                break;
            case "EnemyD":
                {
                    goTargetPool = goEnemyD;
                }
                break;

            case "EnemyBulletA":
                {
                    goTargetPool = goBulletEnemyA;
                }
                break;
            case "EnemyBulletB":
                {
                    goTargetPool = goBulletEnemyB;
                }
                break;
            case "EnemyBulletC":
                {
                    goTargetPool = goBulletEnemyC;
                }
                break;
            case "EnemyBulletD":
                {
                    goTargetPool = goBulletEnemyD;
                }
                break;

            case "PlayerBullet":
                {
                    goTargetPool = goBulletPlayer;
                }
                break;
        }

        for (int i = 0; i < goTargetPool.Length; i++)
        {
            if (goTargetPool[i].activeSelf == false)
            {
                goTargetPool[i].SetActive(true);
                return goTargetPool[i];
            }
        }

        return null;
    }
}
