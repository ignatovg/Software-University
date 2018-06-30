using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.MaxSequenceOfEqualElements
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            
            int length = 1;
            int start = 0;

            int bestStart = start;
            int bestLength = length;

            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i-1] == numbers[i])
                {
                    length ++;
                }
                else
                {
                    length = 1;
                    start = i;
                }

                if (bestLength < length)
                {
                    bestLength = length;
                    bestStart = start;
                }
            }
            Console.WriteLine(string.Join(" ",numbers.GetRange(bestStart,bestLength)));
        }
    }
}
