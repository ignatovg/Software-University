using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07.SumArrays
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] arrayOne = Console.ReadLine().Split(' ')
                .Select(int.Parse).ToArray();

            int[] arrayTwo = Console.ReadLine().Split(' ')
                .Select(int.Parse).ToArray();

            int lengthOfFirstArray = arrayOne.Length;
            int lengthOfSecondArray = arrayTwo.Length;
            int maxLength = Math.Max(lengthOfFirstArray, lengthOfSecondArray);
            int[] auxiliaryArr=new int[maxLength];
            for (int i = 0; i < maxLength; i++)
            {
                auxiliaryArr[i] = arrayOne[i % lengthOfFirstArray] +
                                  arrayTwo[i % lengthOfSecondArray];
            }
            Console.WriteLine(string.Join(" ",auxiliaryArr));
        }
    }
}
