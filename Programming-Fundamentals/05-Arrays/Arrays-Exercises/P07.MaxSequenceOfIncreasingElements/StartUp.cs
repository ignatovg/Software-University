using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07.MaxSequenceOfIncreasingElements
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int length = 1;
            int start = 0;

            int bestLength = 0;
            int bestStart = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i - 1] < nums[i])
                {
                    length++;
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
            Console.WriteLine(string.Join(" ",nums.Skip(bestStart).Take(bestLength)));
        }
    }
}
