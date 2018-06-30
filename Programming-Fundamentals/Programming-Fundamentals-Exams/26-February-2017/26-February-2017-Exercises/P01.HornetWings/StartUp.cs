using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.HornetWings
{
    class StartUp
    {
        static void Main(string[] args)
        {
            long wingFlaps = long.Parse(Console.ReadLine());
            decimal distance =decimal.Parse(Console.ReadLine());
            long endurance=long.Parse(Console.ReadLine());

            decimal distanceInMeters = (wingFlaps / 1000) * distance;
            decimal flapsPerSecond = wingFlaps / 100;
            decimal flapsWithRest = (wingFlaps / endurance) * 5;

            Console.WriteLine($"{distanceInMeters:f2} m.");
            Console.WriteLine($"{flapsPerSecond+flapsWithRest} s.");
        }
    }
}
