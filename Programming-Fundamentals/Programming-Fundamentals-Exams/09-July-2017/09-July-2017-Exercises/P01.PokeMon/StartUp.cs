using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.PokeMon
{
    class StartUp
    {
        static void Main(string[] args)
        {
           
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int Y = int.Parse(Console.ReadLine());

            double halfPercentage = N * 0.5;

            int count = 0;
            while (N >= M)
            {
                N -= M;
                count++;
                if (N == halfPercentage && Y != 0)
                {
                    N /= Y;
                }
            }
            Console.WriteLine(N);
            Console.WriteLine(count);
        }
    }
}
