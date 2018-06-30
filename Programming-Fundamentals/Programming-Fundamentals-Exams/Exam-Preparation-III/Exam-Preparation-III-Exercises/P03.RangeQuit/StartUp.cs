using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P03.RangeQuit
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string pattern = @"(\D+)(\d+)";
            string input = Console.ReadLine();

            StringBuilder result = new StringBuilder();
            foreach (Match match in Regex.Matches(input, pattern))
            {
                string text = match.Groups[1].Value.ToUpper();
                int count = int.Parse(match.Groups[2].Value);

                for (int i = 0; i < count; i++)
                {
                      result.Append(text);
                }
            }
            var uniqueSymbols=result.ToString().Distinct().Count();

            Console.WriteLine($"Unique symbols used: {uniqueSymbols}");
            Console.WriteLine(result);
        }
    }
}
