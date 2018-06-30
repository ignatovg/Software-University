using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_SimpleCalculator
{
    class StartUp
    {
        static void Main(string[] args)
        {

            var input = Console.ReadLine();
            var elements = input.Split(' ');
            var stack = new Stack<string>(elements.Reverse());

            while (stack.Count > 1)
            {
                var leftOperand = int.Parse(stack.Pop());
                var operatorr = stack.Pop();
                var rightOperand = int.Parse(stack.Pop());

                if (operatorr == "+")
                {
                    stack.Push((leftOperand + rightOperand).ToString());
                }
                else if (operatorr == "-")
                {
                    stack.Push((leftOperand - rightOperand).ToString());
                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}