using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddNumber
{
    class OddNumber
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            while (true)
            {
                if (number % 2 == 0)
                {
                    Console.WriteLine("Please write an odd number.");
                    number = int.Parse(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine($"The number is: {Math.Abs(number)}");
                    return;
                }
            }
        }
    }
}
