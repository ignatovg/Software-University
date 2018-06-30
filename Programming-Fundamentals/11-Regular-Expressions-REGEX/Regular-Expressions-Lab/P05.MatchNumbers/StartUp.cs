using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P05.MatchNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var pattern = @"(^|(?<=\s))-?\d+(\.\d+)?($|(?=\s))";
            var numberStrings = Console.ReadLine();
            var numbers = Regex.Matches(numberStrings, pattern);

            foreach (Match number in numbers)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine();
        }
    }
}
