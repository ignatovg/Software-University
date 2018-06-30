using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int num = 1; num <= n; num++)
            {
              
                int number = num;
                int sum = 0;

                while (number > 0)
                {
                    sum += number % 10;
                    number /= 10;
                }
                bool isSpecial = (sum == 5 || sum == 7 || sum == 11);
                
                Console.WriteLine($"{num} -> {isSpecial}");
            }
        }
    }
}
