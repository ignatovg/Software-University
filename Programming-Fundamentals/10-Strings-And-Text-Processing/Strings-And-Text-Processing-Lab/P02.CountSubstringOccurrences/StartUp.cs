using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.CountSubstringOccurrences
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();
            string word = Console.ReadLine().ToLower();

            int index = -1;
            int count = 0;

            while (true)
            {
                index = text.IndexOf(word, index + 1);
                if (index==-1)
                {
                    break;
                }
                count++;

            }
            Console.WriteLine(count);
        }
    }
}
