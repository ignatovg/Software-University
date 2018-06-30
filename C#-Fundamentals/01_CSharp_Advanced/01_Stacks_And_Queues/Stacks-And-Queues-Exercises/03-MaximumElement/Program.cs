using System;
using System.Collections;
using System.Linq;

namespace _03_MaximumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var stack = new Stack();
            var maxElement = int.MinValue;

            for (int i = 0; i < N; i++)
            {
                var commands = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                if (commands[0] == 1)
                {
                    stack.Push(commands[1]);
                    if (maxElement < commands[1])
                    {
                        maxElement = commands[1];
                    }
                }
                else if (commands[0] == 2)
                {
                    var elementToPop = stack.Pop();
                    if (maxElement == (int)elementToPop)
                    {
                        maxElement = (int)stack.ToArray().Max();
                    }
                    
                }
                else if (commands[0] == 3)
                {
                   
                    Console.WriteLine(maxElement);
                }
            }
        }
    }
}
