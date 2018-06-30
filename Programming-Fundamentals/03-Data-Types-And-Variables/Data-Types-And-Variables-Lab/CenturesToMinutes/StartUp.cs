using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CenturesToMinutes
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int centures=int.Parse(Console.ReadLine());
            int years = centures * 100;
            int days = (int) (years * 365.2422);
            int hours = 24 * days;
            int minutes = 60 * hours;
            Console.WriteLine($"{centures} centuries = {years} years = {days} days = {hours} hours" +
                              $" = {minutes} minutes");
        }
    }
}
