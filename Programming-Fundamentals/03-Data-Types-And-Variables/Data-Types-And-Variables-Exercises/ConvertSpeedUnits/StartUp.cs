using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertSpeedUnits
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int meters=int.Parse(Console.ReadLine());
            int hours=int.Parse(Console.ReadLine());
            int minutes=int.Parse(Console.ReadLine());
            int seconds=int.Parse(Console.ReadLine());
           int time =  (int)(hours * 3600 + minutes * 60 + seconds);

            float metersPerSec = (float) meters / time;
            Console.WriteLine($"{metersPerSec}");

            float kilometerPerHour = ((float) meters / 1000) / ((float) time / 3600);
            Console.WriteLine(kilometerPerHour);

            float milesPerHour = ((float)meters / 1609) / ((float)time / 3600);
            Console.WriteLine(milesPerHour);

        }
    }
}
