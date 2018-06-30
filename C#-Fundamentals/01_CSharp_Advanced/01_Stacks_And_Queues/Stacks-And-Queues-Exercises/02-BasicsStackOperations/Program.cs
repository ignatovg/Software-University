using System;
using System.Collections;
using System.Linq;

namespace _02_BasicsStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var commands = Console.ReadLine().Split(' ');
            var nNumbers = Console.ReadLine().Split(' ');

            var stack = new Stack();

            var NPush = int.Parse(commands[0]);
            var SPop = int.Parse(commands[1]);
            var XLook = commands[2];

            for (int i = 0; i < NPush-SPop; i++)
            {
                stack.Push(nNumbers[i]);
            }
            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                if (stack.Contains(XLook))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    var minElement = stack.ToArray().Min(a => a);
                    Console.WriteLine(minElement);
                }
            }
        }
    }
}
