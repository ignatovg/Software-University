using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintTriangle
{
    class StartUp
    {
        static void Main(string[] args)
        {
           int end =int.Parse(Console.ReadLine());

            for (int i = 1; i <= end; i++)
            {
                PrintLine(1, i);
            }
            for (int i = end - 1; i >= 1; i--)
            {
                PrintLine(1,i);
            }
        }

        private static void PrintLine(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write($"{i} ");
              
            }
            Console.WriteLine();
        }
    }
}
