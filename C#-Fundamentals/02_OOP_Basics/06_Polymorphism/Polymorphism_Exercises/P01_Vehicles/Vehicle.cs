using System;

public abstract class Vehicle
{
    private double tankCapacity;

    protected Vehicle(double fuelQuantity, double consumptionPerKm, double tankCapacity)
    {
        this.FuelQuantity = fuelQuantity;
        this.ConsumptionPerKm = consumptionPerKm;
        this.TankCapacity = tankCapacity;
    }
    public double FuelQuantity { get; set; }

    public double ConsumptionPerKm { get; set; }

    public double TankCapacity
    {
        get { return tankCapacity; }
        set
        {
            if (value < FuelQuantity)
            {
                FuelQuantity = 0;
            }
            tankCapacity = value;
        }
    }

    public  void Drive(double distance, double increaseConsumption)
    {
        double literPerKm = ConsumptionPerKm + increaseConsumption;

        if (FuelQuantity < distance * literPerKm)
        {
            Console.WriteLine($"{GetType().Name} needs refueling");
        }
        else
        {
            double consumeFuel = distance * literPerKm;
            FuelQuantity = FuelQuantity - consumeFuel;
            Console.WriteLine($"{GetType().Name} travelled {distance} km");

        }
    }

    public virtual void Refuel(double liters)
    {
        if (liters < 1)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }
        if (this.TankCapacity < liters)
        {
            throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
        }
    }

    public override string ToString()
    {
        return "";
    }
}

