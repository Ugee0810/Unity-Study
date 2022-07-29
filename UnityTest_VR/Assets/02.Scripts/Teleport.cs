using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject player;

    public void TeleportPlayer()
    {
        player.transform.position = new Vector3(this.transform.position.x,
                                                this.transform.position.y + 1.5f, // 조금 띄워서
                                                this.transform.position.z);
    }
}
