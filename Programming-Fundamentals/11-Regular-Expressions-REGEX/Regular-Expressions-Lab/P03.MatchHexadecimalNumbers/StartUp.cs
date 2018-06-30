using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P03.MatchHexadecimalNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"\b(?:0x)?[0-9A-F]+\b";

            MatchCollection hexadecimalCollection = Regex.Matches(text, pattern);

            var hexadecimalMatch = hexadecimalCollection
                .Cast<Match>()
                .Select(a => a.Value.Trim())
                .ToArray();

            Console.WriteLine(string.Join(" ",hexadecimalMatch));
        }
    }
}
