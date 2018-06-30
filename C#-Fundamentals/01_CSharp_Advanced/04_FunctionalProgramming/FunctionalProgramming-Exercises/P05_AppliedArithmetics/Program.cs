using System;
using System.Linq;

namespace P05_AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> add = a => a + 1;
            Func<int, int> multiply = a => a * 2;
            Func<int, int> subtract = a => a - 1;
            Action<string> print = s => Console.WriteLine(s);

            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var condition = string.Empty;
            while ((condition = Console.ReadLine()) !="end")
            {
                switch (condition)
                {
                    case "add":
                        numbers = numbers.Select(a => add(a)).ToArray();
                        break;
                    case "subtract":
                        numbers = numbers.Select(a => subtract(a)).ToArray();
                        break;
                    case "multiply":
                        numbers = numbers.Select(a => multiply(a)).ToArray();
                        break;
                    case "print":
                        Console.WriteLine(string.Join(" ",numbers));
                        break;
                }
            }
        }
    }
}
