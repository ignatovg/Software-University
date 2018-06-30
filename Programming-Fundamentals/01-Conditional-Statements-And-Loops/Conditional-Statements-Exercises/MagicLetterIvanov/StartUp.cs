using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicLetterIvanov
{
    class StartUp
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            char skip = char.Parse(Console.ReadLine());

            for (char i = first; i <= second; i++)
            {
                for (char j = first; j <= second; j++)
                {
                    for (char k = first; k <= second; k++)
                    {
                        string result = $"{i}{j}{k} ";
                        if (!result.Contains(skip))
                        {
                            Console.Write(result);
                        }
                    }
                }
            }
            Console.WriteLine();

        }
    }
}
