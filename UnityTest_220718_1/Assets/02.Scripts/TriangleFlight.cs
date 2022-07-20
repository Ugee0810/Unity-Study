using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleFlight : Flight
{
    public TriangleFlight()
    {
        type = FlightType.Triangle;
        name = "Enemy0";
        hp = 100;
        power = 10;
        speed = 1;
    }

    public override void Attack()
    {
        throw new System.NotImplementedException();
    }
}
