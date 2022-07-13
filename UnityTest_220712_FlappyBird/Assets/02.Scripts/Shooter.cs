using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    void Start()
    {
        
    }

    void Update()
    {
        GameObject goBullet = Instantiate(bulletPrefab);
        goBullet.transform.position = new Vector2(Random.Range(-7f, 7f), Random.Range(-4f, 4f));
    }
}
