using System;

public class Car
{
    private int tankMaxCapacity;

    protected internal Car(int hp, double fuelAmount,Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
        tankMaxCapacity = 160;
    }
    public int Hp { get; private set; }

    public double FuelAmount { get; private set; }

    public Tyre Tyre { get; protected internal set; }

    public void Refuel(double inFuelAmount)
    {
        //possible bug
        if(this.FuelAmount + inFuelAmount >= tankMaxCapacity)
        {
            this.FuelAmount = 160;
        }
        else
        {
            FuelAmount += inFuelAmount;
        }
    }

    public void ReduceAmount(double trackLenght, double fuelConsumption)
    {
        this.FuelAmount -= (trackLenght * fuelConsumption);
        if(this.FuelAmount < 0)
        {
            throw new ArgumentException("Out of fuel");
        }
    }
}

