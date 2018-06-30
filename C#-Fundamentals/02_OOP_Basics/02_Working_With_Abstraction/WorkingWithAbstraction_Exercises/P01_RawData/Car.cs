using System.Collections.Generic;

class Car
{
    public string Model;
    public int EngineSpeed;
    public int EnginePower;
    public int CargoWeight;
    public string CargoType;
    public KeyValuePair<double, int>[] Tires;

    public Car()
    {
        
    }

    public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType, double tire1Pressure, int tire1Age, double tire2Pressure, int tire2Age, double tire3Pressure, int tire3Age, double tire4Pressure, int tire4Age)
    {
        this.Model = model;
        this.EngineSpeed = engineSpeed;
        this.EnginePower = enginePower;
        this.CargoWeight = cargoWeight;
        this.CargoType = cargoType;
        this.Tires = new KeyValuePair<double, int>[] { KeyValuePair.Create(tire1Pressure, tire1Age), KeyValuePair.Create(tire2Pressure, tire2Age), KeyValuePair.Create(tire3Pressure, tire3Age), KeyValuePair.Create(tire4Pressure, tire4Age) };
    }

    public Car ParseCommand(string[] parameters)
    {

        string model = parameters[0];
        int engineSpeed = int.Parse(parameters[1]);
        int enginePower = int.Parse(parameters[2]);
        int cargoWeight = int.Parse(parameters[3]);
        string cargoType = parameters[4];
        double tire1Pressure = double.Parse(parameters[5]);
        int tire1Age = int.Parse(parameters[6]);
        double tire2Pressure = double.Parse(parameters[7]);
        int tire2Age = int.Parse(parameters[8]);
        double tire3Pressure = double.Parse(parameters[9]);
        int tire3Age = int.Parse(parameters[10]);
        double tire4Pressure = double.Parse(parameters[11]);
        int tire4Age = int.Parse(parameters[12]);

        Car car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, tire1Pressure, tire1Age, tire2Pressure, tire2Age, tire3Pressure, tire3Age, tire4Pressure, tire4Age);
        return car;
    }
    
}