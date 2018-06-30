using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberInReversedOrder
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            PrintInReversedOrder(number);

        }

        private static void PrintInReversedOrder(string number)
        {
            var reversed = number.Reverse().ToArray();
            Console.WriteLine(string.Join("",reversed));
        }
    }
}
