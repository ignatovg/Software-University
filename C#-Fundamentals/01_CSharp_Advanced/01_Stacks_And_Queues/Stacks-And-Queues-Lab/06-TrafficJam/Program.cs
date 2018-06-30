using System;
using System.Collections;

namespace _06_TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            var nCars = int.Parse(Console.ReadLine());
            var command = Console.ReadLine();

            var queueCars = new Queue();
            var totalPassedCars = 0;

            while (command != "end")
            {
                if (command == "green")
                {
                    var minLength = Math.Min(nCars, queueCars.Count);
                    for (int i = 0; i < minLength; i++)
                    {
                        Console.WriteLine($"{queueCars.Dequeue()} passed!");
                        totalPassedCars++;
                    }
                }
                else
                {
                    queueCars.Enqueue(command);
                }
                    
                command = Console.ReadLine();
            }
            Console.WriteLine($"{totalPassedCars} cars passed the crossroads.");
        }
    }
}
