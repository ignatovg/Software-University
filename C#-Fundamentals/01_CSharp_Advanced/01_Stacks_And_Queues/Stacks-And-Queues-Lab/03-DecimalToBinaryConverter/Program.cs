using System;
using System.Collections.Generic;

namespace _03_DecimalToBinaryConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            var decimalInput = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();

            if (decimalInput == 0)
            {
                Console.WriteLine(0);
                return;
            }

            while (decimalInput > 0)
            {
                var reminder = decimalInput % 2;
                decimalInput /= 2;
                stack.Push(reminder);
            }

            while (stack.Count!=0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}