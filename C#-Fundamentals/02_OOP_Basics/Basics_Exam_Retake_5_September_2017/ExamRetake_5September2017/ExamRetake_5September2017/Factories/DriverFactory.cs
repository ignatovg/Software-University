using System;
using System.Collections.Generic;
using System.Linq;

public class DriverFactory
{
    readonly TyreFactory tyreFactory = new TyreFactory();

    public Drivers CreateDriver(List<string> commandArgs)
    {
        var type = commandArgs[0];
        var name = commandArgs[1];
        var hp = int.Parse(commandArgs[2]);
        var fuelAmount = double.Parse(commandArgs[3]);

        var tyreArgs = commandArgs.Skip(4).ToList();

        switch (type)
        {
            case "Aggressive":
              
                Car argCar = new Car(hp,fuelAmount,tyreFactory.CreateTyre(tyreArgs));
                return new AggressiveDriver(name, argCar);
                

            case "Endurance":
                Car endurCar = new Car(hp,fuelAmount,tyreFactory.CreateTyre(tyreArgs));
                return new EnduranceDriver(name, endurCar);
            default:
                throw new ArgumentException("Invalid car type!");
        }

    }
}

