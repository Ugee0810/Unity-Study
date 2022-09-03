using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FlightType
{
    Circle,
    Triangle
}

public abstract class Flight : MonoBehaviour
{
    protected GameObject goPlayer;

    protected FlightType type;
    protected string name;
    protected float  health;
    protected float  speed;
    protected float  power;
    protected int nDmgPoint;

    protected Sprite[] sprites;
    protected SpriteRenderer spriteRenderer;

    protected float curBulletDelay = 0f;
    protected float maxBulletDelay;

    void Start()
    {
        
    }

    public abstract void Move();
    public abstract void SetPlayer();
    public abstract void Attack();
    public abstract void OnHit(float playerBulletPower);
    public abstract void ReturnSprite();
}