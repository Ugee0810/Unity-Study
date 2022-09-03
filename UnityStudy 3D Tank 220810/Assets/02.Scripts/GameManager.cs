using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    public int GetTeamFill()
    {
        int[] size = PhotonNetwork.CurrentRoom.GetSize();
        int teamNo = 0;

        int min = size[0];
        for (int i = 0; i < teams.Length; i++)
        {

        }
    }

    [System.Serializable]
    public class Team
    {
        public string name;
        public Material material;
        public Transform spawn;
    }
}
