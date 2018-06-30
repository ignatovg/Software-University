using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackIn30Min
{
    class BackInMin
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            minutes += 30;

            if (minutes > 59)
            {
                hours++;
                if (hours > 23)
                {
                    hours = 0;
                }
                minutes -= 60;
            }
            Console.WriteLine($"{hours}:{minutes:d2}");
        }
    }
}
