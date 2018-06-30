using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P02.ExtractSentencesByKeyword
{
    class StartUp
    {
        static void Main(string[] args)
        {

            string keyword = Console.ReadLine();
            string text = Console.ReadLine();
            string pattern = $@"\b{keyword}\b";

            string[] splittedStrings = Regex.Split(text, "[!?.]");

           Regex regex=new Regex(pattern);

            for (int i = 0; i < splittedStrings.Length; i++)
            {
                if (regex.IsMatch(splittedStrings[i]))
                {
                    Console.WriteLine(splittedStrings[i].Trim());
                }

            }

          
        }
    }
}
