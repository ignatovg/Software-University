using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P03.AnonymousVox
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string encodedText = Console.ReadLine();
            string[] placeholders = Console.ReadLine().Split(new char[] { '{', '}' },
                StringSplitOptions.RemoveEmptyEntries);

            string pattern = @"([A-Za-z]+)(.+)\1";

            MatchCollection mathCollection = Regex.Matches(encodedText, pattern);
            
            List<char> result=new List<char>();
          


            int index = 0;
            int skipLength = 0;
            
            foreach (Match match in mathCollection)
            {
                var allMath = match.Groups[0].Value;
                var placeholder = match.Groups[2].Value;

                
                var strReplace = placeholders[index];

                var replaced = match.Groups[0].Value.Replace(placeholder, strReplace);
                
                index++;

                result.AddRange(encodedText.Skip(skipLength).Take(match.Index-skipLength));
                result.AddRange(replaced);

                skipLength = allMath.Length;
                
            }

            Console.WriteLine(string.Join("", result));
        }
    }
}
