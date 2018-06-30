using System.ComponentModel;

public abstract class Drivers
{
    protected Drivers(string name, Car car)
    {
        this.Name = name;
        this.Car = car;
        this.TotalTime = 0;
    }
    public string Name { get; private set; }

    public double TotalTime { get; private set; }

    public Car Car{ get; private set; }

    public abstract double FuelConsumptionPerKm { get; }

    public virtual double Speed => (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;

    public void SetTime(double seconds)
    {
        this.TotalTime += seconds;
    }
    
}
