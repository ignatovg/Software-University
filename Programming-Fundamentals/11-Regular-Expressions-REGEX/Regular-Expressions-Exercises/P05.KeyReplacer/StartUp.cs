using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P05.KeyReplacer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] keys = Console.ReadLine().Split(new char[] {'|', '<', '\\'},
                StringSplitOptions.RemoveEmptyEntries).ToArray();

            string text = Console.ReadLine();

            string start = keys[0];
            string end = keys[keys.Length - 1];

            string pattern = $@"{start}(.*?){end}";

            MatchCollection matchCollection = Regex.Matches(text, pattern);

           
            int count = 0;

            foreach (Match match in matchCollection)
            {
                if (match.Groups[1].Value!="")
                {
                    Console.Write(match.Groups[1]);
                }
                else
                {
                    count++;
                }
            }
            if (count == matchCollection.Count)
            {
                Console.WriteLine("Empty result");
            }
           
        }
    }
}
