using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesToKm
{
    class MilesToKm
    {
        static void Main(string[] args)
        {
            double mile = double.Parse(Console.ReadLine());
            double km = 1.60934;
            double distance = mile * km;
            Console.WriteLine($"{distance:f2}");
        }
    }
}
