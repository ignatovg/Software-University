using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P08.MostFrequentNumber
{
    class StartUp
    {
        static void Main(string[] args)
        {

            int[] numbers = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int occurs = 0;
            int index = 0;

            int bestOccurs = 0;
            int bestIndex = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int k = 0; k < numbers.Length; k++)
                {
                    if (numbers[i] == numbers[k])
                    {
                        occurs++;
                        index = i;
                    }
                    
                }
                if (bestOccurs < occurs)
                {
                    bestOccurs = occurs;
                    bestIndex = index;
                }
                occurs = 0;
            }
            Console.WriteLine(numbers[bestIndex]);

        }
    }
}
