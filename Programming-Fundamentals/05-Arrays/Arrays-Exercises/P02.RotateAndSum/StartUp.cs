using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.RotateAndSum
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] intArray = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int n = int.Parse(Console.ReadLine());

            RotateToRight(intArray);

            int[] auxiliary = (int[])intArray.Clone();

            for (int i = 0; i < n - 1; i++)
            {
                RotateToRight(auxiliary);
                SumTwoArrays(intArray, auxiliary);
            }
            Console.WriteLine(string.Join(" ", intArray));
        }

        private static void SumTwoArrays(int[] intArray, int[] auxiliary)
        {
            for (int i = 0; i < intArray.Length; i++)
            {
                intArray[i] = intArray[i] + auxiliary[i];
            }
        }

        private static void RotateToRight(int[] arr)
        {
            int temp = arr[arr.Length - 1];
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (i - 1 == -1)
                {
                    break;
                }
                arr[i] = arr[i - 1];
            }
            arr[0] = temp;
        }
    }
}
