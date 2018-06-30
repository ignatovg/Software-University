using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

public class RaceTower
{
    private DriverFactory driverFactory;
    private TyreFactory tyreFactory;
    private List<Drivers> drivers;
    private double[] trackInfo;
    private string whetherMode;
    private int currentLab;
   public RaceTower()
    {
        this.driverFactory = new DriverFactory();
        this.tyreFactory =new TyreFactory();
        this.drivers = new List<Drivers>();
        this.trackInfo = new double[2];
        this.whetherMode = "Sunny";
        currentLab = 0;
    }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        trackInfo[0] = lapsNumber;
        trackInfo[1] = trackLength;
    }
    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            if (commandArgs.Count == 6 || commandArgs.Count == 7)
            {
                Drivers driver = driverFactory.CreateDriver(commandArgs);
                drivers.Add(driver);
            }
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        var reasonToBox = commandArgs[0];
        var driversName = commandArgs[1];

        Drivers currentDriver = drivers.First(n => n.Name == driversName);
        currentDriver.SetTime(20);

        switch (reasonToBox)
        {
            case "ChangeTyres":
                var tyreType = commandArgs[2];
                var tyreHardness = commandArgs[3];

                var currentDriverTyre = currentDriver.Car.Tyre.Name;
                
                if (currentDriverTyre == "Ultrasoft")
                {
                    var grip = commandArgs[4];
                   currentDriver.Car.Tyre = tyreFactory.CreateTyre(new List<string>{tyreType,tyreHardness,grip});
                }
                else
                {
                    currentDriver.Car.Tyre = tyreFactory.CreateTyre(new List<string> {tyreType, tyreHardness});
                }
                break;

            case "Refuel":
                var fuelAmount = double.Parse(commandArgs[2]);
                currentDriver.Car.Refuel(fuelAmount);
                break;
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
         int numberOfLabs = int.Parse(commandArgs[0]);

        foreach (Drivers driver in drivers)
        {
            //set time
            var trackLength = trackInfo[1];
            var driverSpeed = driver.Speed;
            var formula = 60 / (trackLength / driverSpeed);
            driver.SetTime(formula);

            //reduce amount
            driver.Car.ReduceAmount(trackLength,driver.FuelConsumptionPerKm);

            //degradate tyre
            driver.Car.Tyre.LabDegradate();
        }
            
        
        //“60 / (trackLength / driver’s Speed)”
    }

    public string GetLeaderboard()
    {
        // $"Lap {this.currentLab}/{this.trackInfo[0]}" + Environment.NewLine +
          //      $"{Position number} {Driver’s Name} {Total time / Failure reason}";
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        this.whetherMode = commandArgs[0];
    }

}

