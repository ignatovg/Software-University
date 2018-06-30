public class EnduranceDriver:Drivers
{
    public EnduranceDriver(string name, Car car) : base(name, car)
    {
    }

    public override double FuelConsumptionPerKm => 1.5;
    public override double Speed => base.Speed;
}

