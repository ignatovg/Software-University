using System;
using System.Linq;

namespace P14_ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] collection = Console.ReadLine()
                .Split(' ').Select(int.Parse).ToArray();
            int divisor = int.Parse(Console.ReadLine());
            var result = collection.Reverse().Where(n => n % divisor != 0).ToArray();
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
