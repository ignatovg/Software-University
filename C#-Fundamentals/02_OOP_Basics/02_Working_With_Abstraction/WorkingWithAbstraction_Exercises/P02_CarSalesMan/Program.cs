using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02_CarsSalesman
{

    class CarSalesman
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Engine> engines = new List<Engine>();

            //parse engine to engines
            int engineCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < engineCount; i++)
            {
               engines.Add(ReturnEngine());
            }

            //parse car to cars
            int carCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carCount; i++)
            {
              cars.Add(ReturnCar(engines));
            }

            //print cars
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private static Car ReturnCar(List<Engine> engines)
        {
            string[] parameters = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            string model = parameters[0];
            string engineModel = parameters[1];
            Engine engine = engines.FirstOrDefault(x => x.Model == engineModel);

            int weight = -1;

            if (parameters.Length == 3 && int.TryParse(parameters[2], out weight))
            {
               return new Car(model, engine, weight, "n/a");
            }
            else if (parameters.Length == 3)
            {
                string color = parameters[2];
                return new Car(model, engine, -1, color);
            }
            else if (parameters.Length == 4)
            {
                string color = parameters[3];
                return new Car(model, engine, int.Parse(parameters[2]), color);
            }
            else
            {
                return new Car(model, engine);
            }
        }

        private static Engine ReturnEngine()
        {
            string[] parameters = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            string model = parameters[0];
            int power = int.Parse(parameters[1]);

            int displacement = -1;

            if (parameters.Length == 3 && int.TryParse(parameters[2], out displacement))
            {
               return new Engine(model, power, displacement, "n/a");
            }
            else if (parameters.Length == 3)
            {
                string efficiency = parameters[2];
               return new Engine(model, power, -1, efficiency);
            }
            else if (parameters.Length == 4)
            {
                displacement = int.Parse(parameters[2]);
                string efficiency = parameters[3];

               return new Engine(model, power, displacement, efficiency);
            }
            else
            {
               return new Engine(model, power);
            }
        }
    }
}
