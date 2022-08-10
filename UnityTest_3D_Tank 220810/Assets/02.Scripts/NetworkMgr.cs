using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using HashTable = ExitGames.Client.Photon.Hashtable;

public class NetworkMgr : MonoBehaviourPunCallbacks
{
    /// <summary>
    /// 싱글톤
    /// </summary>
    private static NetworkMgr instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
    }

    public static NetworkMgr GetInstance()
    {
        return instance;
    }

    /// <summary>
    /// 포톤 네트워크 설계
    /// </summary>
    public override void OnDisconnected(DisconnectCause cause)
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    private string keyPlayerName = "name";

    public void Connect() => PhotonNetwork.ConnectUsingSettings();

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.NickName = PlayerPrefs.GetString(keyPlayerName);

        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        if (!PhotonNetwork.IsMasterClient) return;

        StartCoroutine(WaitSceneChange());
        OnPlayerEnteredRoom(PhotonNetwork.LocalPlayer);
    }

    IEnumerator WaitSceneChange()
    {
        while (SceneManager.GetActiveScene().buildIndex != 1)
        {
            yield return null;
        }

        OnPlayerEnteredRoom(PhotonNetwork.LocalPlayer);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (!PhotonNetwork.IsMasterClient) return;

        int teamIdx = GameManager.GetInstance().GetTeamFill();
        PhotonNetwork.CurrentRoom.AddSize(teamIdx, +1);
        newPlayer.SetCustomProperties(new HashTable() { { "team", (byte)teamIdx } });
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 2 });
    }

    public override void OnCreatedRoom()
    {
        HashTable roomProps = new Hashtable();
        roomProps.Add(RoomExtensions.size, new int[2]);
        roomProps.Add(RoomExtensions.score, new int[2]);
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomProps);

        PhotonNetwork.LoadLevel(1);
    }

    public static void StartMatch()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.NickName = PlayerPrefs.GetString(PrefesKeys.PlayerName);

        PhotonNetwork.ConnectUsingSettings();
    }
}

public static class RoomExtensions
{
    public const string size = "size";
    public const string score = "score";

    // 사이즈 정의
    public static int[] GetSize(this Room room)
    {
        return (int[])room.CustomProperties[size];
    }

    public static int[] AddSize(this Room room, int teamIdx, int value)
    {
        int[] sizes = room.GetSize();
        sizes[teamIdx] += value;

        room.SetCustomProperties(new Hashtable() { { size, sizes } });
        return sizes;
    }

    // 스코어 정의
    public static int[] GetScore(this Room room)
    {
        return (int[])room.CustomProperties[score];
    }

    public static int[] AddScore(this Room room, int teamIdx, int value)
    {
        int[] scores = room.GetScore();
        scores[teamIdx] += value;

        room.SetCustomProperties(new Hashtable() { { score, scores } });
        return scores;
    }
}