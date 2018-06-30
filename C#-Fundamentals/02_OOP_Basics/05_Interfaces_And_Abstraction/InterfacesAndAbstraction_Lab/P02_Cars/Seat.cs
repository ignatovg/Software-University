
using System;
using P02_Cars;
public class Seat:ICar
{
    public string Model { get; }
    public string Color { get; }

    public Seat(string color,string model)
    {
        this.Color = color;
        this.Model = model;
    }

    public void Start()
    {
        Console.WriteLine("Engine start");
    }

    public void Stop()
    {
        Console.WriteLine("Breaaak!");
    }
}

