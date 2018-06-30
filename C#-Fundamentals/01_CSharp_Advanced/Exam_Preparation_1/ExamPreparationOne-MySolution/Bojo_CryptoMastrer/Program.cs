using System;
using System.Linq;
using System.Net.Http.Headers;

namespace Bojo_CryptoMastrer
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int mexSequence = 0;

            for (int step = 1; step < numbers.Length; step++)
            {
                for (int index = 0; index < numbers.Length; index++)
                {
                    int currentIndex = index;
                    int nextIndex = (index + step)%numbers.Length;
                    int currentSequrnce = 1;
                    while (numbers[currentIndex] < numbers[nextIndex])
                    {
                        currentIndex = nextIndex;
                        nextIndex += (nextIndex + step) % numbers.Length;
                        currentSequrnce++;
                       
                    }

                    if (currentSequrnce > mexSequence)
                    {
                        mexSequence = currentSequrnce;
                    }
                }
            }
            Console.WriteLine(mexSequence);
        }
    }
}
