using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.SplitByWordCasing
{
    class StartUp
    {
        static void Main(string[] args)
        {
            char[] dividers=
            {
                ',',   ';',  ':', '.',  '!', '(', ')',   '"',  '\'',  '\\',    '/',
                 '[',    ']', ' ',
            };

            List<string> words = Console.ReadLine()
                .Split(dividers,StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<string> lowerCase=new List<string>();
            List<string> upperCase=new List<string>();
            List<string> mixedCase=new List<string>();

            bool isUpper = false;
            for (int i = 0; i < words.Count; i++)
            {
                if (IsAllUpper(words[i]))
                {
                    upperCase.Add(words[i]);
                }
                else if (IsAllLower(words[i]))
                {
                    lowerCase.Add(words[i]);
                }
                else
                {
                    mixedCase.Add(words[i]);
                }

            }
            
            Console.WriteLine("Lower-case: {0}", string.Join(", ", lowerCase));
            Console.WriteLine("Mixed-case: {0}", string.Join(", ", mixedCase));
            Console.WriteLine("Upper-case: {0}",string.Join(", ",upperCase));
        }

       public  static  bool IsAllUpper(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (!Char.IsUpper(input[i]))
                    return false;
            }

            return true;
        }

        public static bool IsAllLower(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (!Char.IsLower(input[i]))
                    return false;
            }

            return true;
        }
    }
}
