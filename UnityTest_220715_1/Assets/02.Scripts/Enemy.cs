using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 0f;
    public float health = 0f;

    // ��������Ʈ ����(�ǰ� ���� �� �̹����� ���ؾ� �ϹǷ� �迭�� ����)
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
