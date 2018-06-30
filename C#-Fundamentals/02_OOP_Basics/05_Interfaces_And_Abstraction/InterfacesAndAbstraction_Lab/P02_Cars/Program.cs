using System;
using System.Collections.Generic;

namespace P02_Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] seatInput = Console.ReadLine().Split(' ');
            string[] teslaINput = Console.ReadLine().Split();

            ICar seat = new Seat(seatInput[0], seatInput[2]);
            ICar tesla = new Tesla(teslaINput[0],teslaINput[3],int.Parse(teslaINput[5]));

            List<ICar> cars = new List<ICar>();
            cars.Add(seat);
            cars.Add(tesla);

            foreach (ICar car in cars)
            {
                car.Start();
                car.Stop();
            }
        }
    }
}
