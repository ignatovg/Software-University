using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.FoldAndSum
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int k = arr.Length / 4;

            int[] firstMiniArray = GetKElements(arr,0,k);
            int[] secondMiniArray = GetKElements(arr, 2 * k + k, 4*k);

            int[] concatenatedArr=new int[2*k];

            Array.Reverse(firstMiniArray);
            for (int i = 0; i < firstMiniArray.Length; i++)
            {
                concatenatedArr[i] = firstMiniArray[i];
            }

            int auxiliaryIndex = k;
            Array.Reverse(secondMiniArray);
            for (int i = 0; i < secondMiniArray.Length; i++)
            {
                concatenatedArr[auxiliaryIndex] = secondMiniArray[i];
                auxiliaryIndex++;
            }
           
            int[] middleArray = GetKElements(arr, k, 2 * k + k);

            for (int i = 0; i < middleArray.Length; i++)
            {
                middleArray[i] += concatenatedArr[i];
            }
            Console.WriteLine(string.Join(" ",middleArray));

        }

        private static int[] GetKElements(int[] array, int startIndex,int endIndex)
        {
            int[] newArr= new int[endIndex-startIndex];
            int newIndex = 0;
            for (int i = startIndex; i < endIndex; i++)
            {
                newArr[newIndex] = array[i];
                newIndex++;
            }
            return newArr;
        }
    }
}
