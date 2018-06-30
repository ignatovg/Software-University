using System;
using System.Collections;

namespace _05_HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            var kidsArr = Console.ReadLine().Split(' ');
            var toss = int.Parse(Console.ReadLine());

            var kidsQueue = new Queue(kidsArr);

            while (kidsQueue.Count > 1)
            {
                for (int i = 1; i < toss; i++)
                {
                    kidsQueue.Enqueue(kidsQueue.Dequeue());
                }

                Console.WriteLine($"Removed {kidsQueue.Dequeue()}");
            }
            Console.WriteLine($"Last is {kidsQueue.Dequeue()}");
        }
    }
}
