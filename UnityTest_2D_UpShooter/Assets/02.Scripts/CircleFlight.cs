using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleFlight : Flight
{
    public CircleFlight()
    {
        type = FlightType.Circle;
        name = "Enemy0";
        health = 50;
        speed = 2;
        power = 5;
    }

    private void Start()
    {

    }

    public override void Move()
    {
        //
    }

    public override void Attack()
    {
        //
    }

    public override void SetPlayer()
    {
        goOriginPlayer = goPlayer;
    }
}
