using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriplesOfLetters
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int number=int.Parse(Console.ReadLine());

            for (int a = 0; a < number; a++)
            {
                for (int b = 0; b < number; b++)
                {
                    for (int c = 0; c < number; c++)
                    {
                        char letterA= (char) ('a' + a);
                        char letterB = (char) ('a' + b);
                        char letterC = (char) ('a' + c);
                        Console.WriteLine($"{letterA}{letterB}{letterC}");
                    }
                }
            }
        }
    }
}
