using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace FactorialTrailingZeroes
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n=int.Parse(Console.ReadLine());
                Console.WriteLine(PrintZeroes(n));
        }

        private static int PrintZeroes(int n)
        {
            BigInteger factorial = PrintFactorial(n);
            int count = 0;
            while (factorial!=0)
            {
                BigInteger lastDigit = factorial % 10;
                if (lastDigit != 0)
                {
                    return count;
                }
                factorial /= 10;
                count++;

            }
            return count;
        }
        private static BigInteger PrintFactorial(int n)
        {
            BigInteger factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}
