using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{
    [Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;

        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }

    // 8x8 Size
    public int colums = 8;
    public int rows   = 8;

    public Count wallCount = new Count(5, 9); // 부술 수 있는 벽 생성 할 갯수
    public Count foodCount = new Count(1, 5); // 음식 생성 할 갯수

    public GameObject   exit;
    public GameObject[] floorTiles;
    public GameObject[] outerWallTiles;
    public GameObject[] wallTiles;
    public GameObject[] foodTiles;
    public GameObject[] enemyTiles;

    private Transform boardHolder; // 하이어라키에서 나열되는걸 가려주기 위함
    private List<Vector3> gridPosition = new List<Vector3>(); // 8x8사이즈의 보드판에서 담아있는 정보를 확인하는 리스트

    void InitailiseList()
    {
        gridPosition.Clear();

        for (int x = 1; x < colums - 1; x++)
        {
            for (int y = 1; y < rows - 1; y++)
            {
                gridPosition.Add(new Vector3(x, y, 0f)); // 0, 1 / 0, 2 / 1, 1 / ... / 8, 8
            }
        }
    }

    void BoardSetup() // 정방면 보드 생성 알고리즘
    {
        boardHolder = new GameObject("Board").transform; // 게임오브젝트가 만들어지면 항상 트랜스폼 정보가 나오는데, 그것을 변수로 넘겨준다.

        for (int x = -1; x < colums + 1; x++)
        {
            for (int y = -1; y < rows + 1; y++)
            {
                GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)]; // 플로어 타일에서 랜덤하게 가져온다.

                if (x == -1 || x == colums || y == -1 || y == rows) // 테두리인 경우엔
                    toInstantiate = outerWallTiles[Random.Range(0, outerWallTiles.Length)]; // 외벽 타일 중 하나를 생성

                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0), Quaternion.identity);
                instance.transform.SetParent(boardHolder);
            }
        }
    }

    Vector3 RandomPosition() // 게임이 시작될 때 마다 랜덤하게 생성
    {
        Vector3 randomPosition = Vector3.zero; // 초기화

        int randomIdx = Random.Range(0, gridPosition.Count); // 그리드 포지션의 수 만큼 랜덤하게 가져온다.

        randomPosition = gridPosition[randomIdx];

        gridPosition.RemoveAt(randomIdx); // 중복 제거

        return randomPosition;
    }

    void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
    {
        int objectCount = Random.Range(minimum, maximum + 1); // tileArray로 벽, 음식, 소다 타일들을 생성

        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();

            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];

            Instantiate(tileChoice, randomPosition, Quaternion.identity);
        }
    }

    public void SetupScene(int level)
    {
        BoardSetup();

        InitailiseList();

        LayoutObjectAtRandom(wallTiles, wallCount.minimum, wallCount.maximum); // 부술   벽 최소 / 최대 생성
        LayoutObjectAtRandom(foodTiles, foodCount.minimum, foodCount.maximum); // 음식 타일 최소 / 최대 생성

        // Enemy는 레벨에 따라 증가하는 로직
        int enemyCount = (int)Mathf.Log(level, 2f);

        LayoutObjectAtRandom(enemyTiles, enemyCount, enemyCount);

        Instantiate(exit, new Vector3(colums - 1, rows - 1, 0f), Quaternion.identity); // Exit는 구석에 생성
    }
}
