using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.ReverseString
{
    class StartUp
    {
        static void Main(string[] args)
        {

            var str = Console.ReadLine();
            var reverseStr = str.Reverse().ToArray();

            Console.WriteLine(reverseStr);
        }
    }
}
