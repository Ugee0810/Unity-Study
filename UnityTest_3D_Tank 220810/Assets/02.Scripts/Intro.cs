using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public GameObject loadingWindow;
    public Text txtServerLog;     // 서버 접속 정보 받아오기
    public InputField nameFiled;  // 유저 네임 받아오기

    private void Start()
    {
        // 유저 네임
        nameFiled.text = string.Format("User" + System.String.Format("{0:0000}", Random.Range(1, 9999)));
        // 클라우드 플랫폼 또는 파이어베이스에서 유저 정보를 관리
    }

    private void OnDisable()
    {
        PlayerPrefs.SetString(PrefesKeys.PlayerName, nameFiled.text);
    }

    public void Play()
    {
        loadingWindow.SetActive(true);
        NetworkMgr.StartMatch();
        StartCoroutine(HandleTimeOut());
    }

    IEnumerator HandleTimeOut()
    {
        yield return new WaitForSeconds(10);

        Photon.Pun.PhotonNetwork.Disconnect();
        OnConectionError();
    }
     
    void OnConectionError()
    {
        StopAllCoroutines();
        loadingWindow.SetActive(false);
    }
}
