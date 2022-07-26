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

    void Update()
    {
        // 플레이 타임은 델타타임을 사용하여 증가
        if (isBattle) playTime += Time.deltaTime;
    }

    // 인게임 UI
    void LateUpdate()
    {
        scoreTxt.text        = string.Format("{0:n0}", player.score);
        stageTxt.text        = "STAGE " + stage;
        // 초단위 시간을 3600, 60으로 나누어 시분초로 계산
        int hour   = (int)(playTime / 3600);
        // 시간을 먼저 계산하고 남은 것을 빼준다.
        int min    = (int)(playTime - hour * 3600 / 60);
        int second = (int)(playTime % 60);
        playTimeTxt.text = string.Format("{0:00}", hour  ) + ":" +
                           string.Format("{0:00}", min   ) + ":" +
                           string.Format("{0:00}", second);
        playerHealthTxt.text = player.health + " / " + player.maxHealth;
        playerCoinTxt.text   = string.Format("{0:n0}", player.coin);

        // 무기를 보유하지 않았다면,
        if (player.equipWeapon == null) playerAmmoTxt.text = "- / " + player.ammo;
        // 보유한 무기가 근접 무기라면,
        else if (player.equipWeapon.type == Weapon.Type.Melee) playerAmmoTxt.text = "- / " + player.ammo;
        else playerAmmoTxt.text = player.equipWeapon.curAmmo + " / " + player.ammo;

        // 무기 아이콘은 보유 상황에 따라 알파값만 변경
        weapon1Img.color = new Color(1, 1, 1, player.hasWeapons[0]   ? 1 : 0);
        weapon2Img.color = new Color(1, 1, 1, player.hasWeapons[1]   ? 1 : 0);
        weapon3Img.color = new Color(1, 1, 1, player.hasWeapons[2]   ? 1 : 0);
        weaponRImg.color = new Color(1, 1, 1, player.hasGranades > 0 ? 1 : 0);

        enemyATxt.text = enemyCntA.ToString();
        enemyBTxt.text = enemyCntB.ToString();
        enemyCTxt.text = enemyCntC.ToString();
    }
}
