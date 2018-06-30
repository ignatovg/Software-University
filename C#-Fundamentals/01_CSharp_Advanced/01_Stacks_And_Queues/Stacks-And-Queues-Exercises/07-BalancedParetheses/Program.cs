using System;
using System.Collections;

namespace _07_BalancedParetheses
{
    class Program
    {
        static void Main(string[] args)
        {
            var parentheses = Console.ReadLine();
            var stack = new Stack();

            for (int i = 0; i < parentheses.Length; i++)
            {
                if (stack.Count==0 && (parentheses[i] == ')' || parentheses[i] == ']' || parentheses[i] == '}'))
                {
                    Console.WriteLine("NO");
                    return;
                }
                
                if (parentheses[i] == ')')
                    {
                        if (!stack.Pop().Equals('('))
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                    }
                    else if (parentheses[i] == ']')
                    {
                        if (!stack.Pop().Equals('['))
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                    }
                    else if (parentheses[i] == '}')
                    {
                        if (!stack.Pop().Equals('{'))
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                    }
                    else
                    {
                        stack.Push(parentheses[i]);
                    }
            }
            Console.WriteLine("YES");
        }
    }
}
