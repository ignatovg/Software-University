using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsAndObjects
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string str1 = "Hello";
            string str2 = "World";
            object obj = str1 + " " + str2;
            string str3 = (string)obj;
            Console.WriteLine(str3);
        }
    }
}
