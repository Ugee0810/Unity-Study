using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 1. 변수 생성
// 2. 게임 매니저 오브젝트 할당 및 초기화
// 3. 
public class GameManager : MonoBehaviour
{
    public GameObject menuCam;
    public GameObject gameCam;
    // 게임오브젝트 대신 스크립트로 가져옴
    public Player player;
    public Boss boss;

    public GameObject menuPanel;
    public Text maxScoreTxt;

    public GameObject gamePanel;
    // Score Group
    public Text scoreTxt;
    public Text stageTxt;
    public Text playTimeTxt;
    // Status Group
    public Text playerHealthTxt;
    public Text playerAmmoTxt;
    public Text playerCoinTxt;
    // Equip Group
    public Image weapon1Img;
    public Image weapon2Img;
    public Image weapon3Img;
    public Image weaponRImg;
    // Enemy Group
    public Text enemyATxt;
    public Text enemyBTxt;
    public Text enemyCTxt;
    // Boss Group
    public RectTransform bossHealthGroup;
    public RectTransform bossHealthBar;

    public int stage;
    public float playTime;

    public bool isBattle;
    public int enemyCntA;
    public int enemyCntB;
    public int enemyCntC;

    void Awake()
    {
        maxScoreTxt.text = string.Format("{0:n0}", PlayerPrefs.GetInt("MaxScore"));
    }

    // 게임 스타트 버튼 클릭 이벤트
    public void GameStart()
    {
        menuCam.SetActive(false);
        gameCam.SetActive(true);

        menuPanel.SetActive(false);
        gamePanel.SetActive(true);

        player.gameObject.SetActive(true);
    }

    // 인게임 UI

}
