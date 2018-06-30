using System;
using System.Linq;

namespace P03_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var stack = new Stack<string>();

                string input;
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] tokens = input.Split();

                    switch (tokens[0])
                    {
                        case "Push":
                            var data = tokens.Skip(1).Select(i => i.TrimEnd(',')).Where(i => i != "").ToArray();
                            stack.Push(data);
                            break;

                        case "Pop":
                            stack.Pop();
                            break;
                    }
                }
                Console.WriteLine(string.Join("\n", stack));

                foreach (var item in stack)
                {
                    Console.WriteLine(item);
                }
            }
            catch (ArgumentException m)
            {
                Console.WriteLine(m.Message);
            }
        }
    }
}
