using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplyEvensByOdds
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int number=int.Parse(Console.ReadLine());
            number=Math.Abs(number);
            var result = GetMultiplyOfEvenAndOdds(number);
            Console.WriteLine(result);
        }

        private static int GetMultiplyOfEvenAndOdds(int number)
        {
            int sumOfEvens = 0;
            int sumOfOdds = 0;

            while (number>0)
            {
                int lastDigit = number % 10;
                if (lastDigit % 2 == 0)
                {
                    sumOfEvens += lastDigit;
                }
                else
                {
                    sumOfOdds += lastDigit;
                }
                number /= 10;
            }
            return sumOfOdds * sumOfEvens;
        }
        
    }
}
