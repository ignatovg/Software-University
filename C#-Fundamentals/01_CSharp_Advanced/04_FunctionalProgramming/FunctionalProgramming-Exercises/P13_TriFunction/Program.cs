using System;
using System.Linq;

namespace P13_TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> filter = (str, len) =>
            {
                int sum = 0;
                foreach (char ch in str)
                {
                     sum += ch;
                }
                return sum >= len;
            };
            int length = int.Parse(Console.ReadLine());
            var first = Console.ReadLine().Split(' ').FirstOrDefault(str => filter(str, length));
            Console.WriteLine(first);
        }
    }
}
