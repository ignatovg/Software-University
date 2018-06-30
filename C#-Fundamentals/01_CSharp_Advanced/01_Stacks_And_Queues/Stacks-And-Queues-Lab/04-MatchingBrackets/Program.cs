using System;
using System.Collections.Generic;

namespace _04_MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var exp = Console.ReadLine();
            var stack = new Stack<int>();

            for (int i = 0; i < exp.Length; i++)
            {
                if (exp[i] == '(')
                {
                    stack.Push(i);
                }
                else if (exp[i] == ')')
                {
                    var leftBracketIndex = stack.Pop();

                    Console.WriteLine(exp.Substring(leftBracketIndex,i-leftBracketIndex+1));
                }
            }
        }
    }
}
