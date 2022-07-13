using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeltaTime : MonoBehaviour
{
    float speed = 20.0f;

    float startTime;
    float startDeltaTime;

    void Start()
    {
        startTime = Time.time;
        startDeltaTime = Time.time;
    }

    void Update()
    {
        float t = Time.time - startTime;
        startDeltaTime = Time.deltaTime * 1.0f;

        Debug.Log("Time : " + t);
        Debug.Log("DeltaTime : " + startDeltaTime);

        //float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");

        //h = h * speed * Time.deltaTime;
        //v = v * speed * Time.deltaTime;

        //transform.Translate(Vector2.right * h);
        //transform.Translate(Vector2.up    * v);
    }
}
