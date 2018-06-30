using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P02._1.ExtractSentencesByKeyword
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine();

            string[] sentences = text.Split(new char[] {'?', '!', '.'},
                StringSplitOptions.RemoveEmptyEntries);
           
            string pattern = $@"\b{word}\b";

            Regex regex=new Regex(pattern);

            foreach (string sentence in sentences)
            {
                if (regex.IsMatch(sentence))
                {
                    Console.WriteLine(sentence.Trim());
                }
            }
        }
    }
}
