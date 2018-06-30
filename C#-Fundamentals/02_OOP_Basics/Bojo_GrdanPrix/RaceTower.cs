using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

public class RaceTower
{
    private const string crashReason = "Crashed";

    private IList<Driver> racingDrivers;
    private Stack<Driver> failedDrivers;
    private Track track;

    public RaceTower()
    {
        this.racingDrivers = new List<Driver>();
        this.failedDrivers = new Stack<Driver>();
    }

    public bool IsRaceOver { get; set; }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.track = new Track(lapsNumber, trackLength);
    }
    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            string driverType = commandArgs[0];
            string name = commandArgs[1];

            int hp = int.Parse(commandArgs[2]);
            double fuelAmount = double.Parse(commandArgs[3]);

            string[] tyreArgs = commandArgs.Skip(4).ToArray();


            Tyre tyre = this.CreateTyre(tyreArgs);
            Car car = new Car(hp, fuelAmount, tyre);
            Driver driver = this.CreateDriver(driverType, name, car);

            this.racingDrivers.Add(driver);
        }
        catch { }

    }

    private Driver CreateDriver(string type, string name, Car car)
    {
        Driver driver = null;
        if (type == "Aggressive")
        {
            driver = new AggressiveDriver(name, car);
            return driver;
        }
        else if (type == "Endurance")
        {
            driver = new EnduranceDriver(name, car);
            return driver;
        }
        throw new ArgumentException(OutputMesseges.InvalidDriverType);
    }

    private Tyre CreateTyre(string[] tyreArgs)
    {
        string tyreType = tyreArgs[0];
        double tyreHardness = double.Parse(tyreArgs[1]);

        Tyre tyre = null;

        if (tyreType == "Hard")
        {
            tyre = new HardTyre(tyreHardness);
        }
        else if (tyreType == "Ultrasoft")
        {
            double grip = double.Parse(tyreArgs[2]);
            tyre = new UltrasoftTyre(tyreHardness, grip);
        }

        if (tyre == null)
        {
            throw new ArgumentException(OutputMesseges.InvalidTyreType);
        }
        return tyre;
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        string boxReason = commandArgs[0];
        string driverName = commandArgs[1];

        Driver driver = racingDrivers.FirstOrDefault(n => n.Name == driverName);
        string[] methodArgs = commandArgs.Skip(2).ToArray();

        if (boxReason == "Refuel")
        {
            driver.Refuel(methodArgs);
        }
        else if (boxReason == "ChangeTyres")
        {
            Tyre tyre = CreateTyre(methodArgs);
            driver.ChangeTyres(tyre);
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        StringBuilder builder = new StringBuilder();

        int numberOfLaps = int.Parse(commandArgs[0]);

        if (numberOfLaps > this.track.LapsNumber - this.track.CurrentLab)
        {
            try
            {
                throw new ArgumentException(string.Format(OutputMesseges.InvalidLaps, this.track.CurrentLab));
            }
            catch (ArgumentException e)
            {
               return (e.Message);
            }
        }

        for (int index = 0; index < this.racingDrivers.Count; index++)
        {
            Driver driver = this.racingDrivers[index];
            try
            {
                driver.CompliteLap(this.track.TrackLength);
            }
            catch (ArgumentException ae)
            {
                driver.Fail(ae.Message);
                this.failedDrivers.Push(driver);
                this.racingDrivers.RemoveAt(index);
                index--;
            }
        }

        var orderedDrivers = this.racingDrivers
            .OrderByDescending(d => d.TotalTime)
            .ToList();

        for (int i = 0; i < orderedDrivers.Count - 1; i++)
        {
            Driver overtakingDriver = orderedDrivers[i];
            Driver targetDriver = orderedDrivers[i + 1];

            bool overtakeHappened = this.TryOverTake(overtakingDriver, targetDriver);

            if (overtakeHappened)
            {
                i++;
                builder.AppendLine(string.Format(OutputMesseges.OverTakeMessege, overtakingDriver.Name,
                    targetDriver.Name, this.track.CurrentLab));

            }
            else
            {
                if (!overtakingDriver.IsRacing)
                {
                    this.failedDrivers.Push(overtakingDriver);
                    orderedDrivers.RemoveAt(i);
                    i--;
                }
                
            }

        }
        string result = builder.ToString().TrimEnd();
        return result;
    }

    private bool TryOverTake(Driver overtakingDriver, Driver targetDriver)
    {
        double timeDiff = overtakingDriver.TotalTime - targetDriver.TotalTime;
       

        bool aggresiveDriver = overtakingDriver is AggressiveDriver &&
                               overtakingDriver.Car.Tyre is UltrasoftTyre;

        bool enduranseDriver = overtakingDriver is EnduranceDriver &&
                               overtakingDriver.Car.Tyre is HardTyre;

        bool crash = (aggresiveDriver && this.track.Weather == Weather.Foggy) ||
            (enduranseDriver && this.track.Weather == Weather.Rainy);

        if (enduranseDriver || aggresiveDriver && timeDiff <= 3)
        {
            if (crash)
            {
                overtakingDriver.Fail(crashReason);
                return false;
            }
            overtakingDriver.TotalTime -= 3;
            targetDriver.TotalTime += 3;
            return true;
        }

        else if (timeDiff <= 2)
        {
            overtakingDriver.TotalTime -= 2;
            targetDriver.TotalTime += 2;
            return true;
        }

        return false;
    }

    public string GetLeaderboard()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine($"Lap {this.track.CurrentLab}/{this.track.LapsNumber}");

        IEnumerable<Driver> leaderBoardDrivers = this.racingDrivers.OrderBy(t => t.TotalTime).Concat(this.failedDrivers);

        int position = 1;
        foreach (Driver driver in leaderBoardDrivers)
        {
            builder.AppendLine($"{position} {driver.ToString()}");
            position++;
        }
        string result = builder.ToString().TrimEnd();
        return result;
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        string weatherType = commandArgs[0];

        bool validWeather = Enum.TryParse(typeof(Weather), weatherType, out object weatherObj);

        if (!validWeather)
        {
            throw new ArgumentException(OutputMesseges.InvalidWeatherType);
        }

        Weather weather = (Weather)weatherObj;
        this.track.Weather = weather;
    }

}
