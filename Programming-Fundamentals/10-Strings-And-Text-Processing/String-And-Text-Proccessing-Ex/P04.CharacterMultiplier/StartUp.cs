using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.CharacterMultiplier
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split(' ');
            
            Console.WriteLine(CharakterMupltiplier(line[0],line[1]));
        }

        private static int CharakterMupltiplier(string str1, string str2)
        {
            int maxLength = Math.Max(str1.Length, str2.Length);
            int result = 0;
            int compare = 0;
            for (int i = 0; i < maxLength; i++)
            {
                if (i > str1.Length-1)
                {
                    compare = 1;
                    break;
                }
               else if (i > str2.Length - 1)
                {
                    compare = -1;
                    break;
                }
                result += str1[i] * str2[i];
            }

            if (compare == -1)
            {
                
                string remStr = str1.Substring(str1.Length - (str1.Length-str2.Length));
                return result+SumLetters(remStr);
            }
            else if(compare==1)
            {
                string remStr = str2.Substring(str2.Length - (str2.Length - str1.Length));
                return result+SumLetters(remStr);
            }
            else
            {
                return result;
            }
        }

        private static int SumLetters(string str)
        {
            int result = 0;
            for (int i = 0; i < str.Length; i++)
            {
                result += str[i];
            }
            return result;
        }
    }
}
