using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P01._1.MatchFullNames
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";

            MatchCollection matchedNames = Regex.Matches(text, pattern);

            foreach (Match match in matchedNames)
            {
                Console.Write(match+" ");
            }
            Console.WriteLine();
        }
    }
}
