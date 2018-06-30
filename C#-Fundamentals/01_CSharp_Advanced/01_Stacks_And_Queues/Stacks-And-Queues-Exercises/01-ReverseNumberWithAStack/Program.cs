using System;
using System.Collections;

namespace _01_ReverseNumberWithAStack
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputArr = Console.ReadLine().Split(' ');
            var stack = new Stack(inputArr);

            while (stack.Count > 1)
            {
                Console.Write(stack.Pop() + " ");
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
