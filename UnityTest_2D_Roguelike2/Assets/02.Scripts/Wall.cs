using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite dmgSprite;
    public int wallHp = 3;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void DamageWall(int loss)
    {
        spriteRenderer.sprite = dmgSprite;

        wallHp -= loss;

        if (wallHp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
