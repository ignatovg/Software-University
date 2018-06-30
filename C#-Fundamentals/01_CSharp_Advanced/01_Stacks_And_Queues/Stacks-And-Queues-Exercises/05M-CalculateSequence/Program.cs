using System;
using System.Collections.Generic;
using System.Linq;

namespace _05M_CalculateSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = long.Parse(Console.ReadLine());

            var queue = new Queue<long>();
            queue.Enqueue(n);
            int index = 0;

            while (queue.Count > 0)
            {
                index++;
                long current = queue.Dequeue();
                Console.Write(current + " ");
                if (index == 50)
                {
                    Environment.Exit(0);
                }
                queue.Enqueue(current + 1);
                queue.Enqueue(2 * current + 1);
                queue.Enqueue(current + 2);
            }
        }
    }
}
