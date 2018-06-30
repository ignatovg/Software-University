using System;

public class Car:Vehicle
{
    public Car(double fuelQuantity, double consumptionPerKm, double tankCapacity) : base(fuelQuantity, consumptionPerKm, tankCapacity)
    {
    }

   
    public override void Refuel(double liters)
    {
        base.Refuel(liters);
        FuelQuantity += liters;
    }

    public override string ToString()
    {
        return $"Car: {FuelQuantity:f2}";
    }

    
}
