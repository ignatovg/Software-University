using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawAFilledSquare
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n =int.Parse(Console.ReadLine());
            PrintDashes(n);
            for (int i = 0; i < n/2; i++)
            {
                PrintSquareLine(n);
            }
          
            PrintDashes(n);
        }

        private static void PrintSquareLine(int n)
        {
            
            Console.Write("-");
            for (int i = 1; i < n; i++)
            {
                Console.Write("\\/");
            }
            Console.WriteLine("-");
        }

        private static void PrintDashes(int n)
        {
            Console.WriteLine(new string('-',2*n));
        }
    }
}
