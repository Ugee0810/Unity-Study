using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite dmgSprite;
    public int wallHp = 3;

    public AudioClip hitSound1;
    public AudioClip hitSound2;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void DamageWall(int loss)
    {
        SoundManager.instance.RandomizeSfx(hitSound1, hitSound2);
        spriteRenderer.sprite = dmgSprite;

        wallHp -= loss;

        if (wallHp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
