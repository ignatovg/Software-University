using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P02._1.MatchPhoneNumber
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string numbers = Console.ReadLine();
            string pattern = @"\+359( |-)2\1(\d{3})\1(\d{4})\b";

            MatchCollection phoneMatches = Regex.Matches(numbers, pattern);

            var matchedPhones = phoneMatches
                .Cast<Match>()
                .Select(a => a.Value.Trim())
                .ToArray();
            Console.WriteLine(string.Join(", ",matchedPhones));
        }
    }
}
