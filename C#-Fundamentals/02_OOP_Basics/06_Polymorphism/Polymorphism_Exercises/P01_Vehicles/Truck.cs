using System;

class Truck:Vehicle
{
    public Truck(double fuelQuantity, double consumptionPerKm, double tankCapacity) : base(fuelQuantity, consumptionPerKm, tankCapacity)
    {
    }

    public override void Refuel(double liters)
    {
        base.Refuel(liters);
        FuelQuantity += (liters * 0.95);
    }

    public override string ToString()
    {
        return $"Truck: {FuelQuantity:f2}";
    }

   
}
