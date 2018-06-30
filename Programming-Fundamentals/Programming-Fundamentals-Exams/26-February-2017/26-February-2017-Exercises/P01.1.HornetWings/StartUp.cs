using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01._1.HornetWings
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n=int.Parse(Console.ReadLine());
            double m =double.Parse(Console.ReadLine());
            int p=int.Parse(Console.ReadLine());

            int rest = n / p;
            long seconds = rest * 5L;
            double distance = (n / 1000) * m;
            seconds += (n / 100);

            Console.WriteLine($"{distance:f2} m.");
            Console.WriteLine($"{seconds} s.");
        }
    }
}
