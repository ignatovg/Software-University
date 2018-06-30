using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastPrimeChecker_Refactor
{
    class StartUp
    {
        static void Main(string[] args)
        {

            int input = int.Parse(Console.ReadLine());

            for (int i = 2; i <= input; i++)
            {
                bool isPrime = true;

                for (int z = 2; z <= Math.Sqrt(i); z++)
                {
                    if (i % z == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                Console.WriteLine($"{i} -> {isPrime}");

            }

        }
    }
}
