using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.MagicExchangeableWords
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine().Split(' ').ToArray();

            var str1 = line[0];
            var str2 = line[1];

            if (str1.Length > str2.Length)
            {
                string temp = str1;
                str1 = str2;
                str2 = temp;
            }

            var dict=new Dictionary<char,char>();
            bool isExchangeable = true;

            for (int i = 0; i < str1.Length; i++)
            {
                char char1 = str1[i];
               
                char char2 = str2[i];

                if (!dict.ContainsKey(char1))
                {
                   dict.Add(char1,char2);
                }
                else
                {
                    if (dict[char1]!=char2)
                    {
                        isExchangeable = false;
                        break;
                    }
                }
            }

            if (str1.Length != str2.Length)
            {
                string rem = str2.Substring(str1.Length);

                for (int i = 0; i < rem.Length; i++)
                {
                    char letter = rem[i];

                    if (!dict.ContainsValue(letter))
                    {
                        isExchangeable = false;
                        break;
                    }
                }
            }
           
            if (isExchangeable)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}
