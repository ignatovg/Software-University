using System;
using System.Collections;
using System.Linq;

namespace _04_BasicsQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var commands = Console.ReadLine().Split(' ');
            var nNumbers = Console.ReadLine().Split(' ');

            var queue = new Queue();

            var NPush = int.Parse(commands[0]);
            var SPop = int.Parse(commands[1]);
            var XLook = commands[2];

            for (int i = 0; i < NPush; i++)
            {
                queue.Enqueue(nNumbers[i]);
            }
            for (int i = 0; i < SPop; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                if (queue.Contains(XLook))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    var minElement = queue.ToArray().Min();
                    Console.WriteLine(minElement);
                }

            }

        }
    }
}
