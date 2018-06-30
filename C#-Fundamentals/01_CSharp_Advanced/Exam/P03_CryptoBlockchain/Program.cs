using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace P03_CryptoBlockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> blocks = new List<string>();

            for (int i = 0; i < n; i++)
            {
              blocks.Add(Console.ReadLine());    
            }

            StringBuilder wholeString = new StringBuilder();

            for (int i = 0; i < blocks.Count; i++)
            {
                wholeString.Append(blocks[i]);
            }

            string bigParrern = @"\[(.*)(\d){3}(.*)\]";
            string smallParrern = @"\{(.*)(\d){3}(.*)\}";
            string digits = @"\d+";
           

            for (int i = 0; i < wholeString.Length; i++)
            {
                if (wholeString[i] == '{')
                {
                    var match = Regex.Match(wholeString.ToString(), smallParrern).ToString();
                    if (match[0] == '{' && match[match.Length - 1] == ']')
                    {
                        continue;
                    }
                    var takeDigits = Regex.Match(match.ToString(), digits).ToString();

                    if (takeDigits.Length % 3 != 0)
                    {
                        continue;
                    }
                    int blockLenght = match.Length;

                    for (int j = 0; j < takeDigits.Length; j += 3)
                    {
                        string digitAsStr = takeDigits[j].ToString() + takeDigits[j+1].ToString()+takeDigits[j+2];
                        int digitAsInt = int.Parse(digitAsStr);
                        Console.Write((char)(digitAsInt-blockLenght));
                    }
                    i = i + blockLenght;
                }

                if (wholeString[i] == '[')
                {
                    var match = Regex.Match(wholeString.ToString(), bigParrern).ToString();

                    Console.WriteLine(match);
                    Console.WriteLine(i);
                    Console.WriteLine(wholeString);
                    if (match != "")
                    {
                        if (match[0] == '[' && match[match.Length - 1] == '}')
                        {
                            continue;
                        }
                        var takeDigits = Regex.Match(match.ToString(), digits).ToString();

                        if (takeDigits.Length % 3 != 0)
                        {
                            continue;
                        }
                        int blockLenght = match.Length;

                        for (int j = 0; j < takeDigits.Length; j += 3)
                        {
                            string digitAsStr = takeDigits[j].ToString() + takeDigits[j + 1].ToString() +
                                                takeDigits[j + 2];
                            int digitAsInt = int.Parse(digitAsStr);
                            Console.Write((char) (digitAsInt - blockLenght));
                        }

                        wholeString.Remove(0, blockLenght - 1);
                    }
                }
            }
            Console.WriteLine();
            
        }
    }
}
