using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Factorial
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n=int.Parse(Console.ReadLine());
            PrintFactorial(n);
        }

        private static void PrintFactorial(int n)
        {
            BigInteger factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }
            Console.WriteLine(factorial);
        }
    }
}
