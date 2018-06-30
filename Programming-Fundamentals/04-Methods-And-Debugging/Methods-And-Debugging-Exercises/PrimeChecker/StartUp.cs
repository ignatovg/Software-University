using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace PrimeChecker
{
    class StartUp
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            Console.WriteLine(IsPrime(n));
        }

        static bool IsPrime(long number)
        {
            if (number == 1 || number == 0)
            {
                return false;
            }
            if (number == 2)
            {
                return true;
            }

            for (int i = 2; i <= Math.Ceiling(Math.Sqrt(number)); ++i)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
