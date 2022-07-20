using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FlightGenerator : MonoBehaviour
{
    public List<Flight> flights = new List<Flight>();

    public List<Flight> GetFlights()
    {
        return flights;
    }

    public abstract void CreateFlight();
}

public class TriangleFlightGenerator : FlightGenerator
{
    public override void CreateFlight()
    {
        flights.Clear();
        flights.Add(new TriangleFlight());
        flights.Add(new TriangleFlight());
        flights.Add(new TriangleFlight());
    }
}

public class CircleFlightGenerator : FlightGenerator
{
    public override void CreateFlight()
    {
        flights.Clear();
        flights.Add(new CircleFlight());
        flights.Add(new CircleFlight());
        flights.Add(new CircleFlight());
    }
}