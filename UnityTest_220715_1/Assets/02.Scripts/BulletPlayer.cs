using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    public float hitPower = 0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")  Destroy(gameObject);
        if (collision.gameObject.tag == "Enemies") Destroy(gameObject);
    }
}