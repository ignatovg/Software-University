using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P01.ExtractEmails
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var pattern = @"(?<=\s|^)([A-Za-z0-9]+[._-]?[A-Za-z0-9]+)+@([A-Za-z]+[._-]?)+\.[A-Za-z]+\b";
            var text = Console.ReadLine();

            MatchCollection matchCollection = Regex.Matches(text, pattern);

            foreach (Match match in matchCollection)
            {
                Console.WriteLine(match);
            }
        }
    }
}
