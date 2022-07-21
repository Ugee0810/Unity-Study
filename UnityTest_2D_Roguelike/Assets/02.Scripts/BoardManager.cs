using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{
    [Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;

        public Count (int min, int max)
        {
            this.minimum = min;
            this.maximum = max;
        }
    }
    
    // 8 x 8 Size
    public int colums = 8;
    public int rows   = 8;

    public Count wallCount = new Count(5, 9);
    public Count foodCount = new Count(1, 5);

    public GameObject exit;
    public GameObject[] floorTiles;
    public GameObject[] wallTiles;
    public GameObject[] foodTiles;
    public GameObject[] enemyTiles;
    public GameObject[] otherWallTiles; // 바깥 테두리 타일

    private Transform boardHolder;
    private List<Vector2> gridPositions = new List<Vector2> (); // 한 곳에 같은, 다른 타일이 있는지 중복 확인

    public void SetupScene(int level)
    {
        InitialiseList();
        boardSetup();
        LayoutObjectAtRandom(wallTiles, wallCount.minimum, wallCount.maximum);
    }    

    void InitialiseList()
    {
        gridPositions.Clear();

        for (int x = 0; x < colums; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                gridPositions.Add(new Vector3 (x, y, 0));
            }
        }
    }

    void boardSetup() // 정방면 보드 생성 알고리즘
    {
        boardHolder = new GameObject("Board").transform;
        for (int x = -1; x < colums + 1; x++)
        {
            for (int y = -1; y < rows + 1; y++)
            {
                GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];

                if (x == -1 || x == colums || y == -1 || y == rows)
                    toInstantiate = otherWallTiles[Random.Range(0, otherWallTiles.Length)];

                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity);

                instance.transform.SetParent(boardHolder);
            }
        }
    }

    void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
    {
        int objectCount = Random.Range(minimum, maximum);

        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPositon = RandomPositon();
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];

            Instantiate(tileChoice, randomPositon, Quaternion.identity);
        }
    }
    Vector3 RandomPositon()
    {
        int randIdx = Random.Range(0, gridPositions.Count);

        Vector3 randPosition = gridPositions[randIdx];
        gridPositions.RemoveAt(randIdx);

        return randPosition; // 다음에 불러올 때 중첩되지 않도록 좌표를 지운다.
    }
}
