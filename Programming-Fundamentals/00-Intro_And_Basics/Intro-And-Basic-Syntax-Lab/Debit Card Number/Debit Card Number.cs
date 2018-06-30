using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debit_Card_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstInt =int.Parse(Console.ReadLine());
            int secondInt =int.Parse(Console.ReadLine());
            int thirdInt =int.Parse(Console.ReadLine());
            int fourthInt =int.Parse(Console.ReadLine());
            Console.WriteLine($"{firstInt:d4} {secondInt:d4} {thirdInt:d4} {fourthInt:d4}");
        }
    }
}
