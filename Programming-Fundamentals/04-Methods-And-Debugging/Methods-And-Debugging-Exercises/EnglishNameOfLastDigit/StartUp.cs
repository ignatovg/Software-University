using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EnglishNameOfLastDigit
{
    class StartUp
    {
        static void Main(string[] args)
        {

            string integer = Console.ReadLine();
            PrintTheNameOfLastDigit(integer);
        }

        private static void PrintTheNameOfLastDigit(string integer)
        {
            integer = integer.Substring(integer.Length - 1);
            string[] arr = new[]
            {
                "zero", "one", "two", "three", "four", "five", "six",
                "seven", "eight", "nine"
            };
            int index =int.Parse(integer);
            Console.WriteLine(arr[index]);
        }
    }
}
