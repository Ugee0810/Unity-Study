using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 0f;
    public float health = 0f;

    // 스프라이트 변수(피격 당할 때 이미지가 변해야 하므로 배열로 정의)
    public Sprite[] sprites;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        spriteRenderer.sprite = sprites[1];
        Invoke("ReturnSprite", 0.1f); // startcoroutine
        
    }

    private void FixedUpdate()
    {
        
    }

    void ReturnSprite()
    {
        spriteRenderer.sprite = sprites[0];
    }
}
