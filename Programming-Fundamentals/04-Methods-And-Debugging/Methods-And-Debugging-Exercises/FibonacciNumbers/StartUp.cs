using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n=int.Parse(Console.ReadLine());

            Console.WriteLine(Fib(n));
        }

        private static int Fib(int number)
        {

            int a = 0;
            int b = 1;
            for (int i = 0; i <= number; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }
    }
}
