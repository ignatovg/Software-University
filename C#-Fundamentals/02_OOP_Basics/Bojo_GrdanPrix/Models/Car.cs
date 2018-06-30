using System;

public class Car
{
    private const double maxFuel = 160;

    private double fuelAmount;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;

    }
    public int Hp { get; }

    public double FuelAmount
    {
        get => this.fuelAmount;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(OutputMesseges.OutOfFuel);
            }
            this.fuelAmount = Math.Min(value, maxFuel);
        }
    }

    public Tyre Tyre { get; private set; }

    public void Refuel(double fuelAmount)
    {
        this.FuelAmount += fuelAmount;
    }

    public void ChangeTyres(Tyre tyre)
    {
        this.Tyre = tyre;
    }

    public void CompleteLap(double trackLenght, double fuelConsumption)
    {
        this.FuelAmount -= trackLenght * fuelConsumption;

        this.Tyre.CompleteLab();
    }
}

