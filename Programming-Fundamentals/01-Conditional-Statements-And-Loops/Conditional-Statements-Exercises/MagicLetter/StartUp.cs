using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicLetter
{
    class StartUp
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            char escapeChar = char.Parse(Console.ReadLine());
            for (char i = firstChar; i <= secondChar; i++)
            {
                for (char j = firstChar; j <= secondChar; j++)
                {
                    for (char k = firstChar; k <= secondChar; k++)
                    {
                        if (i != escapeChar && j != escapeChar && k != escapeChar)
                        {
                            Console.Write($"{i}{j}{k} ");
                        }

                    }
                }
            }
            Console.WriteLine();
        }
    }
}
