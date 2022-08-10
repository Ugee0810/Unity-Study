using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class MatchMaker : MonoBehaviourPunCallbacks
{
    public GameObject photonObject;

    void Start()
    {
        Debug.Log("Start()");

        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.GameVersion = "0.1";
    }

    // 조인 타입
    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster()");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom() was Called by PUN. Now this client is in a room.");

        float randomX = Random.Range(-6f, 6f);

        PhotonNetwork.Instantiate(
            photonObject.name,
            new Vector3(randomX, 1f, 0f),
            Quaternion.identity,
            0);

        GameObject mainCamera = GameObject.FindWithTag("MainCamera");
        mainCamera.GetComponent<Camera>().enabled = true;
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);

        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 4 });
    }
}
