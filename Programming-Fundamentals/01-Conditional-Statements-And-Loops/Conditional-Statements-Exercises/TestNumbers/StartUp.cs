using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int boundaty = int.Parse(Console.ReadLine());

            int totalSum = 0;
            int combinations = 0;

            for (int i = N; i >= 1; i--)
            {
                for (int j = 1; j <= M; j++)
                {

                    totalSum += 3 * (i * j);
                    combinations++;
                    if (totalSum >= boundaty)
                    {
                        Console.WriteLine($"{combinations} combinations");
                        Console.WriteLine($"Sum: {totalSum} >= {boundaty}");
                        return;
                    }


                }
            }
            Console.WriteLine($"{combinations} combinations");
            Console.WriteLine($"Sum: {totalSum}");


        }
    }
}
