using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.UnicodeCharacters
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string txt = Console.ReadLine();

            StringBuilder unicode=new StringBuilder();

            for (int i = 0; i < txt.Length; i++)
            {
                char letter = txt[i];
                int intValue = letter;
                string hexValue = intValue.ToString("x");

                unicode.Append($"\\u00{hexValue}");
             
            }
          
            Console.WriteLine(unicode);
        }
    }
}
