using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CenturiesToNanoseconds
{
    class StartUp
    {
        static void Main(string[] args)
        {
            
            int centures = int.Parse(Console.ReadLine());
            int years = centures * 100;
            int days = (int)(years * 365.2422);
            int hours = 24 * days;
            int minutes = 60 * hours;
            BigInteger seconds = 60 * (BigInteger)minutes;
            BigInteger miliseconds = 1000 * seconds;
            BigInteger microsecond = 1000 * miliseconds;
            BigInteger nanoseconds = 1000000 * miliseconds;

            Console.WriteLine($"{centures} centuries = {years} years = {days} days = {hours} hours" +
                              $" = {minutes} minutes = {seconds} seconds = {miliseconds} milliseconds" +
                              $" = {microsecond} microseconds = {nanoseconds} nanoseconds");
        }
    }
}
