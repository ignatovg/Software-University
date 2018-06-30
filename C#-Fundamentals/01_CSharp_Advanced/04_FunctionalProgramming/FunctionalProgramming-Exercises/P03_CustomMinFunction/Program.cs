using System;
using System.Linq;

namespace P03_CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            Func<int, int, bool> expression = (x, y) => x < y;
            Action<int> print = a => Console.WriteLine(a);

            int minElement = int.MaxValue;

            foreach (var currentElement in input)
            {
                minElement = MinElement(minElement, currentElement, expression);
            }
            print(minElement);
        }

        public static int MinElement(int el1,int el2, Func<int,int, bool> min)
        {
            if (min(el1,el2))
            {
                return el1;
            }
            return el2;
        }
    }
}
