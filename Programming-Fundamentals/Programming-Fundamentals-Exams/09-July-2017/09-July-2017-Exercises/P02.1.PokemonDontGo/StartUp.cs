using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02._1.PokemonDontGo
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();

            int index = 0;

            while (true)
            {
                string bojomon = string.Empty;
                string didimon = string.Empty;

                if (index == inputLine.Length)
                {
                    break;
                }

                didimon = FindSymbols(inputLine, ref index);
                if (didimon!=string.Empty)
                {
                    Console.WriteLine(didimon);
                }

                if (index == inputLine.Length)
                {
                    break;
                }

                bojomon = FindPokewords(inputLine, ref index);
                if (bojomon != string.Empty)
                {
                    Console.WriteLine(bojomon);
                }


            }
        }

        

        

        private static string FindPokewords(string inputLine, ref int index)
        {

            StringBuilder result=new StringBuilder();
            bool isDash = false;

            for (int i = index; i < inputLine.Length; i++)
            {
                if (Char.IsLetter(inputLine[i]) ||  inputLine[i] == '-')
                {

                    if (inputLine[i] == '-' && !isDash)
                    {
                        isDash = true;
                        result.Append(inputLine[i]);
                    }
                    if (!isDash)
                    {
                        result.Append(inputLine[i]);
                    }

                }
                else
                {
                    index = i;
                    return result.ToString();
                }
            }
            index = inputLine.Length;
            return result.ToString();
        }

        public static string FindSymbols(string inputLine, ref int  index)
        {
            StringBuilder result=new StringBuilder();
            for (int i = index; i < inputLine.Length; i++)
            {
                if (!Char.IsLetter(inputLine[i]) && inputLine[i]!='-')
                {
                    result.Append(inputLine[i]);
                }
                else
                {
                    index = i;
                    return result.ToString();
                }
            }
            index = inputLine.Length;
            return result.ToString();
        }
    }
}
