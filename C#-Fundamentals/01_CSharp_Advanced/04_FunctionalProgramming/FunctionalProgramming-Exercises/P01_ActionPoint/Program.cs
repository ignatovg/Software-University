using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = s => Console.WriteLine(s);

                Console.ReadLine()
                .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(print);
        }
    }
}
