using System;
using P02_Cars;
public class Tesla:ICar,IElectricCar
{
    public string Model { get; }
    public string Color { get; }
    public int Battery { get; }

    public Tesla(string color,string model, int battery)
    {
        this.Model = model;
        this.Color = color;
        this.Battery = battery;
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

