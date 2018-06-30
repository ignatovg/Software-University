using System;
using System.Collections.Generic;
using System.Linq;

namespace P08_CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, bool> extension = n => n % 2 == 0;
            var numbers = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var result = PrintNums(numbers, extension);
            Console.WriteLine(string.Join(" ", result));
        }

        private static List<int> PrintNums(IEnumerable<int> numbers, Func<int, bool> extension)
        {
            List<int> evenNums = numbers
                .Where(n => extension(n))
                .OrderBy(n => n)
                .ToList();
            List<int> oddNums = numbers
                .Where(n => !extension(n))
                .OrderBy(n => n)
                .ToList();

            evenNums.AddRange(oddNums);

            return evenNums;
        }
    }
}
