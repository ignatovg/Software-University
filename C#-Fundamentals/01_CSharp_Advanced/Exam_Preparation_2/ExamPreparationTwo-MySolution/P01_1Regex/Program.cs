using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P01_1Regex
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\[\w+<(\d+)REGEH(\d+)>\w+\]";

            var input = Console.ReadLine();

            var regex = new Regex(pattern);

            var indexes = new List<int>();
            foreach (Match match in regex.Matches(input))
            {
                
                indexes.Add(int.Parse(match.Groups[1].Value));
                indexes.Add(int.Parse(match.Groups[2].Value));
            }
            int currentIndex = 0;
            foreach (var index in indexes)
            {
                currentIndex += index;
                var charIndex = currentIndex % (input.Length - 1);
                Console.Write(input[charIndex]);
            }

        }
    }
}
