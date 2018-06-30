using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.DayOfWeek
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int numOfDay=int.Parse(Console.ReadLine());

            string[] days =
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday",
            };
            if (numOfDay >=1 && numOfDay <= 7)
            {
                Console.WriteLine(days[numOfDay-1]);
            }
            else
            {
                Console.WriteLine("Invalid Day!");
            }
        }
    }
}
