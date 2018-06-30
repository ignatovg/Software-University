using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorSpecialNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 1; i <= n; i++)
            {
                int number = i;
                while (i > 0)
                {
                    sum += i % 10;
                    i = i / 10;
                }
                bool isSpecial = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine($"{number} -> {isSpecial}");
                sum = 0;
                i = number;
            }
        }
    }
}
