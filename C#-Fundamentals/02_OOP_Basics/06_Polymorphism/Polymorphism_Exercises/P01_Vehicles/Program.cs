using System;

namespace P01_Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputCar = Console.ReadLine().Split();
            string[] inputTruck = Console.ReadLine().Split();
            string[] inputTBus = Console.ReadLine().Split();

            Vehicle car = new Car(double.Parse(inputCar[1]), double.Parse(inputCar[2]),double.Parse(inputCar[3]));
            Vehicle truck = new Truck(double.Parse(inputTruck[1]), double.Parse(inputTruck[2]),double.Parse(inputTruck[3]));
            Vehicle bus = new Bus(double.Parse(inputTBus[1]), double.Parse(inputTBus[2]), double.Parse(inputTBus[3]));

            int nLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < nLines; i++)
            {

                try
                {
                    string[] commandArgs = Console.ReadLine().Split();
                    string command = commandArgs[0];
                    string vehicle = commandArgs[1];
                    double doubleNumber = double.Parse(commandArgs[2]);

                    if (command == "Drive")
                    {
                        if (vehicle == "Car")
                        {
                            car.Drive(doubleNumber, 0.9);
                        }
                        else if (vehicle == "Truck")
                        {
                            truck.Drive(doubleNumber, 1.6);
                        }
                        else if (vehicle == "Bus")
                        {
                            bus.Drive(doubleNumber, 1.4);
                        }
                    }
                    else if (command == "Refuel")
                    {
                        if (vehicle == "Car")
                        {
                            car.Refuel(doubleNumber);
                        }
                        else if (vehicle == "Truck")
                        {
                            truck.Refuel(doubleNumber);
                        }
                        else if (vehicle == "Bus")
                        {
                            bus.Refuel(doubleNumber);
                        }
                    }
                    else if (command == "DriveEmpty")
                    {
                        bus.Drive(doubleNumber, 0);
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }
    }
}
