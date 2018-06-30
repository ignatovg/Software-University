using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
           int n = int.Parse(Console.ReadLine());
           Dictionary<string,Car> cars = new Dictionary<string, Car>();

            for (int i = 0; i < n; i++)
            {
                string[] readCar = Console.ReadLine().Split(' ');
                string model = readCar[0];
                double fuelAmount = double.Parse(readCar[1]);
                double fuelConsumption = double.Parse(readCar[2]);

                cars[model] = new Car(model,fuelAmount,fuelConsumption);
            }

            string commandArgs = string.Empty;
            while ((commandArgs=Console.ReadLine())!= "End")
            {
                string carModel = commandArgs.Split(' ')[1];
                double amountOfKm = double.Parse(commandArgs.Split(' ')[2]);

                cars[carModel].MoveCar(amountOfKm);
            }

            foreach (var car in cars.Values)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.Distance}");
            }
        }
    }
}
