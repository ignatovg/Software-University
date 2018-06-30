using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.PokemonDontGo
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> sequenceOfIntegers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int sumOfRemovedEl = 0;

            while (sequenceOfIntegers.Count != 0)
            {
                int index = int.Parse(Console.ReadLine());

                var removedElement = 0;
                if (index < 0)
                {
                    removedElement = sequenceOfIntegers[0];

                    sequenceOfIntegers.RemoveAt(0);
                    sequenceOfIntegers.Insert(0, sequenceOfIntegers.Last());
                }
                else if (index > sequenceOfIntegers.Count - 1)
                {
                    removedElement = sequenceOfIntegers[sequenceOfIntegers.Count - 1];

                    sequenceOfIntegers.RemoveAt(sequenceOfIntegers.Count - 1);
                    sequenceOfIntegers.Insert(sequenceOfIntegers.Count, sequenceOfIntegers.First());
                }
                else
                {
                    removedElement = sequenceOfIntegers[index];
                    sequenceOfIntegers.RemoveAt(index);
                }

                IncreaseAndDecreaseElements(sequenceOfIntegers, removedElement);

                sumOfRemovedEl += removedElement;
            }
            Console.WriteLine(sumOfRemovedEl);
        }

        private static void IncreaseAndDecreaseElements(List<int> sequenceOfIntegers, int removedElement)
        {
            for (int i = 0; i < sequenceOfIntegers.Count; i++)
            {
                if (sequenceOfIntegers[i] <= removedElement)
                {
                    sequenceOfIntegers[i] += removedElement;
                }
                else
                {
                    sequenceOfIntegers[i] -= removedElement;
                }
            }
        }
    }
}
