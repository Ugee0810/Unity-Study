using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMaker : MonoBehaviour
{
    public GameObject bombPrefab;
    public float interval;
    float delta = 0;

    void Start() { }

    void Update()
    {
        // interval 값 마다 실행(시간)
        delta += Time.deltaTime;
        if (delta > interval)
        {
            delta = 0;
            GameObject bomb = Instantiate(bombPrefab);
            float x = Random.Range(-11.5f, 12.5f);
            bomb.transform.position = new Vector2(x, 8);
        }
    }
}
