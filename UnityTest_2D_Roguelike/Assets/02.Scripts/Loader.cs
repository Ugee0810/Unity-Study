using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject gameManager;

    private void Awake()
    {
        // 메인 카메라에서 로드 될 때 게임 매니저를 프리팹에서 생성한다.
        if (GameManager.instance == null) Instantiate(gameManager);
    }
}
