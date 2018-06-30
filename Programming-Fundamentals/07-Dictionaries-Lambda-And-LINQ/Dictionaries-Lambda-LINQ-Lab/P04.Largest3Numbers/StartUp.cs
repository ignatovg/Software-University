using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.Largest3Numbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .OrderByDescending(x => x)
                .Take(3)
                .ToArray();
            Console.WriteLine(string.Join(" ",nums));
        }
    }
}
