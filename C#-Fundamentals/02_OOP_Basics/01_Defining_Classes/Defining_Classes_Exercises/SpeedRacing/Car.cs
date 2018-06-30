using System;

class Car
{
    public string Model { get; set; }
    public double FuelAmount { get; set; }
    public double FuelConsuption { get; set; }
    public double Distance { get; set; }

    public Car(string model,double fuelAmount,double fuelConsuption)
    {
        this.Model = model;
        this.FuelAmount = fuelAmount;
        this.FuelConsuption = fuelConsuption;
        this.Distance = 0;
    }

    public void MoveCar(double amountOfKm)
    {
      var reducedFuel =  this.FuelAmount - (this.FuelConsuption * amountOfKm);
        if (reducedFuel >= 0)
        {
            this.FuelAmount = reducedFuel;
            this.Distance += amountOfKm;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }
    
}

