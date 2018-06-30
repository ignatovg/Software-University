using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxMethod
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int a=int.Parse(Console.ReadLine());
            int b=int.Parse(Console.ReadLine());
            int c=int.Parse(Console.ReadLine());

            if (a > b)
            {
                GetMax(a, c);
            }
            else
            {
                GetMax(b, c);
            }
        }

        private static void GetMax(int a, int b)
        {
            Console.WriteLine(Math.Max(a, b));
        }
    }
}
