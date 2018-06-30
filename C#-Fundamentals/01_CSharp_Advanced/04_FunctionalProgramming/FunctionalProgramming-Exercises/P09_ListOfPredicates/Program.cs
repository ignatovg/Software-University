using System;
using System.Collections.Generic;
using System.Linq;

namespace P09_ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, bool> filter = (x, z) => x % z == 0;

            void Print(List<int> n) => Console.WriteLine(string.Join(" ", n));

            int length = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            List<int> numbers = AddNumbers(length);

            foreach (var divider in dividers)
            {
                numbers = numbers.Where(num => filter(num, divider)).ToList();
            }
          Print(numbers);
        }

        private static List<int> AddNumbers(int n)
        {
            var result = new List<int>();

            if (n >= 0)
            {
                for (int i = 1; i <= n; i++)
                {
                    result.Add(i);
                }
            }
            return result;
        }
    }
}
