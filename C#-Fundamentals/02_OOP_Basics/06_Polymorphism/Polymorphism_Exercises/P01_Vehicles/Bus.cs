public class Bus : Vehicle
{
    public Bus(double fuelQuantity, double consumptionPerKm, double tankCapacity) : base(fuelQuantity, consumptionPerKm, tankCapacity)
    {
    }


    public override void Refuel(double liters)
    {
        base.Refuel(liters);
        FuelQuantity += liters;
    }

    public override string ToString()
    {
        return $"Bus: {FuelQuantity:f2}";
    }
}

