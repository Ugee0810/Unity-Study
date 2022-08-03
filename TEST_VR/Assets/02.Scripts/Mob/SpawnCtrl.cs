using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCtrl : MonoBehaviour
{
    public GameObject jackOLantern; // 생성할 프리팹(몬스터)

    // 플래그 변수
    public bool playerOnStart = true; // 게임 시작 상태를 관장하는 변수

    public float startFactor = 1f;
    public float additiveFactor = 0.1f;
    public float delayPerSpawnGroup = 3f;

    private void Start()
    {
        if (playerOnStart)
            Play();
        else
            Stop();
    }

    public void Play()
    {
        StartCoroutine(Process());
    }

    public void Stop()
    {
        StopAllCoroutines();
    }

    void Spawn()
    {
        Instantiate(jackOLantern, transform.position, transform.rotation);
    }

    IEnumerator Process()
    {
        var factor = startFactor;
        var wfs = new WaitForSeconds(delayPerSpawnGroup); // 딜레이를 전역 변수로 관리

        while (true)
        {
            yield return wfs;

            yield return StartCoroutine(SpawnProcess(factor));

            factor += additiveFactor;
        }
    }

    IEnumerator SpawnProcess(float factor)
    {
        var count = Random.Range(factor, factor * 2f);

        for (int i = 0; i < count; i++)
        {
            Spawn();

            if (Random.value < 0.2f)
            {
                yield return new WaitForSeconds(Random.Range(0.01f, 0.02f));
            }
        }
    }
}
