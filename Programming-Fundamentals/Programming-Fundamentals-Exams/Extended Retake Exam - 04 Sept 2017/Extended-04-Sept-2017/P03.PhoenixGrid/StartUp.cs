using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.PhoenixGrid
{
    class StartUp
    {
        //40/100 in Judge
        static void Main(string[] args)
        {
            while (true)
            {
                string inputLine = Console.ReadLine();
                if (inputLine == "ReadMe")
                {
                    break;
                }
                string[] tokens = inputLine.Split('.');

                if (IsValidMassege(tokens) && IsPolindrome(tokens))
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");
                }

            }
        }

        private static bool IsPolindrome(string[] tokens)
        {
            int startIndex = 0;
            int endIndex = tokens.Length - 1;
            var tokensLength = tokens.Length / 2;
            while (startIndex <= endIndex)
            {
                string reversedEnd = string.Join("", tokens[endIndex].ToCharArray().Reverse());

                if (tokens[startIndex] != reversedEnd)
                {
                    return false;
                }
                startIndex++;
                endIndex--;
            }

            return true;
        }

        private static bool IsValidMassege(string[] tokens)
        {
            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i].Length != 3 || tokens[i].Contains("_") || tokens[i].Contains(" "))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
