using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace P01_Regex
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\[\w+<(\d+)REGEH(\d+)>\w+\]";

            MatchCollection matchCollection = Regex.Matches(input, pattern);

            int index = 0;
            StringBuilder outputString = new StringBuilder();

            foreach (Match match in matchCollection)
            {
                var firstDigit = int.Parse(match.Groups[1].Value);
                var secondDigit = int.Parse(match.Groups[2].Value);

                index = (index + firstDigit) % input.Length;
                outputString.Append(input[index]);

                index = (index + secondDigit) % input.Length;
                outputString.Append(input[index]);
            }

            Console.WriteLine(outputString);
        }
    }
}
