using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.TextFilter
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] banWords = Console.ReadLine().Split(new string[] {", "},
                StringSplitOptions.RemoveEmptyEntries).ToArray();
            string text = Console.ReadLine();

            foreach (var banWord in banWords)
            {
                string bannedWord=new string('*',banWord.Length);
                text = text.Replace(banWord, bannedWord);
            }
            Console.WriteLine(text);
        }
    }
}
