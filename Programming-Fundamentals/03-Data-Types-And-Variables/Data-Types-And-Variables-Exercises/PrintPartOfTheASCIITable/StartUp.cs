using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintPartOfTheASCIITable
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int startValue=int.Parse(Console.ReadLine());
            int endValue=int.Parse(Console.ReadLine());

            for (int i = startValue; i <= endValue; i++)
            {
                Console.Write((char)i + " ");
            }
            Console.WriteLine();
        }
    }
}
