using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace P02_KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printSir = s => Console.WriteLine($"Sir {s}");

            var input = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            foreach (string str in input)
            {
                printSir(str);
            }
        }
    }
}
