using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P01.MatchFullName
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();

            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";

            Regex regex= new Regex(pattern);

            MatchCollection matches=regex.Matches(text);

            foreach (Match match in matches)
            {
                Console.Write(match+" ");
            }
        }
    }
}
