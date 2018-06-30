using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace CarSaleman
{
    class Program
    {
        private static List<Engine> engines;
        private static List<Car> cars;

        static void Main(string[] args)
        {
            //“<Model> <Power> <Displacement> <Efficiency>
            int n = int.Parse(Console.ReadLine());
            engines = new List<Engine>();
            ReadEngines(n);

            //“<Model> <Engine> <Weight> <Color>”, 
            int m = int.Parse(Console.ReadLine());
            cars = new List<Car>();
            ReadCars(m);
            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                Console.WriteLine($"  Weight: {car.Weight}");
                Console.WriteLine($"  Color: {car.Color}");

            }
         
        }

        private static void ReadCars(int m)
        {

            for (int i = 0; i < m; i++)
            {
                string[] readCars = Console.ReadLine().Split();
                string model = readCars[0];
                string engine = readCars[1];
                string weight = "n/a";
                string color = "n/a";

                if (readCars.Length == 4 && readCars[3] != "")
                {
                    weight = readCars[2];
                    color = readCars[3];
                }
                else if (readCars.Length == 3 ||(readCars.Length == 4 && readCars[3] == ""))
                {

                    if (Char.IsDigit(readCars[2][0]))
                    {
                        weight = readCars[2];
                    }
                    else
                    {
                        color = readCars[2];
                    }
                }
                var engineName = engines.First(a => a.Model == engine);

                Car currentCar = new Car(model, engineName, weight, color);
                cars.Add(currentCar);
            }

        }

        private static void ReadEngines(int n)
        {
            for (int i = 0; i < n; i++)
            {
                string[] readEngines = Console.ReadLine().Split();
                string model = readEngines[0];
                string power = readEngines[1];
                string displacement = "n/a";
                string efficiency = "n/a";

                if (readEngines.Length == 4)
                {
                    displacement = readEngines[2];
                    efficiency = readEngines[3];
                }
                else if (readEngines.Length == 3)
                {
                    if (char.IsDigit(readEngines[2][0]))
                    {
                        displacement = readEngines[2];
                    }
                    else
                    {
                        efficiency = readEngines[2];
                    }
                }
                Engine currentEngine = new Engine(model, power, displacement, efficiency);
                engines.Add(currentEngine);
            }
        }
    }
}
