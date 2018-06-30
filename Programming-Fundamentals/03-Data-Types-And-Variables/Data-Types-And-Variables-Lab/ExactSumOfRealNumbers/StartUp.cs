using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExactSumOfRealNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int boundary=int.Parse(Console.ReadLine());

            decimal sum = 0m;
            for (int i = 0; i < boundary; i++)
            {
                sum+=decimal.Parse(Console.ReadLine());
            }
            Console.WriteLine(sum);
        }
    }
}
