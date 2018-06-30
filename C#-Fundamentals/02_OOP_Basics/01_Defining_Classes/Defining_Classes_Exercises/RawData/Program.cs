using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    class Program
    {
        static void Main(string[] args)
        {
          int n = int.Parse(Console.ReadLine());

            //“<Model> <EngineSpeed> <EnginePower> <CargoWeight> <CargoType> <Tire1Pressure> <Tire1Age> <Tire2Pressure> <Tire2Age> <Tire3Pressure> <Tire3Age> <Tire4Pressure> <Tire4Age>” 
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carArgs = Console.ReadLine().Split();
                string model = carArgs[0];
                int engineSpeed = int.Parse(carArgs[1]);
                int enginePower = int.Parse(carArgs[2]);
                int cargoWeight = int.Parse(carArgs[3]);
                string cargoType = carArgs[4];

                double tire1Pressure = double.Parse(carArgs[5]);
                int tire1Age = int.Parse(carArgs[6]);

                double tire2Pressure = double.Parse(carArgs[7]);
                int tire2Age = int.Parse(carArgs[8]);

                double tire3Pressure = double.Parse(carArgs[9]);
                int tire3Age = int.Parse(carArgs[10]);

                double tire4Pressure = double.Parse(carArgs[11]);
                int tire4Age = int.Parse(carArgs[12]);

                Engine currentEngine = new Engine(engineSpeed,enginePower);
                Cargo currentCargo = new Cargo{CargoType = cargoType,CargoWeight = cargoWeight};
                Tires currenTires = new Tires();
                currenTires.AddPressureTires(tire1Pressure,tire2Pressure,tire3Pressure,tire4Pressure);

                Car currentCar = new Car(model,currentEngine,currentCargo,currenTires);

                cars.Add(currentCar);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                var printCar = cars.Where(a => a.Cargo.CargoType == "fragile");
                 printCar = printCar.Where(a=>a.Tires.pressureTires.Any(b => b < 1.0));

                foreach (Car car in printCar)
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (command == "flamable")
            {
                var printCar = cars.Where(a => a.Cargo.CargoType == "flamable" && a.Engine.EnginePower > 250);
                foreach (Car car in printCar)
                {
                    Console.WriteLine(car.Model);
                }
            }

        }
    }
}
