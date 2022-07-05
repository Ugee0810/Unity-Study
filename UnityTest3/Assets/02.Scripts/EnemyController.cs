using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 0.0f;
    private Rigidbody enemyRd;
    private float moveRate;
    private float timeAfterMove;

    void Start()
    {
        enemyRd = GetComponent<Rigidbody>();

        moveRate = Random.Range(-1.0f, 1.0f);
    }

    void Update()
    {
        enemyRd.AddForce(new Vector3(moveRate, 0, 0));


    }
}
