using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06.MaxSequenceOfEqualElements
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] seqOfElements = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int length = 1;
            int start = 0;

            int bestStart = start;
            int bestLength = length;

            for (int i = 1; i < seqOfElements.Length; i++)
            {
                if (seqOfElements[i - 1] == seqOfElements[i])
                {
                    length++;
                }
                else
                {
                    start = i;
                    length = 1;

                }
                if (bestLength < length)
                {
                    bestStart = start;
                    bestLength = length;
                }
                
            }
            Console.WriteLine(string.Join(" ", seqOfElements.Skip(bestStart).Take(bestLength).ToArray()));
        }
    }
}
