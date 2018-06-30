using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P10.PairsByDifference
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int difference=int.Parse(Console.ReadLine());

            int pairs = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int k = i; k < numbers.Length; k++)
                {
                    bool isPair = Math.Abs(numbers[i] - numbers[k]) == difference;
                    if (isPair)
                    {
                        pairs++;
                    }
                }
            }
            Console.WriteLine(pairs);
        }
    }
}
