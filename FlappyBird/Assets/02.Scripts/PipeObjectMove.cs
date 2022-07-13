using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeObjectMove : MonoBehaviour
{
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x - 0.03f, transform.position.y);
        if (transform.position.x <= -10f)
            Destroy(gameObject);
    }

    void Update()
    {

    }
}
