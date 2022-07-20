using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FlightType
{
    Triangle,
    Circle
}

public abstract class Flight
{
    protected FlightType type;
    protected string name;
    protected float  hp;
    protected float  power;
    protected float  speed;

    public abstract void Attack();
}