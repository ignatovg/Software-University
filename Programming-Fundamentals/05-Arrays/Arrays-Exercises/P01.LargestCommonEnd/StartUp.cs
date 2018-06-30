using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace P01.LargestCommonEnd
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine().Split(' ');
            string[] arr2 = Console.ReadLine().Split(' ');
            int equalsWordsAtStart = 0;
            int indexArr1 = 0;
            int indexArr2 = 0;

            while (true)
            {
                if ((indexArr1 == arr1.Length) || (indexArr2 == arr2.Length))
                {
                    break;
                }
                if (arr1[indexArr1] == arr2[indexArr2])
                {
                    equalsWordsAtStart++;
                }
                else
                {
                    break;
                }
                indexArr1++;
                indexArr2++;
            }

            int equalWordsAtEnd = 0;
            indexArr1 = arr1.Length - 1;
            indexArr2 = arr2.Length - 1;
            while (true)
            {
                if ((indexArr1 == -1) || (indexArr2 == -1))
                {
                    break;
                }
                if (arr1[indexArr1] == arr2[indexArr2])
                {
                    equalWordsAtEnd++;
                }
                else
                {
                    break;
                }
                indexArr1--;
                indexArr2--;
            }
            Console.WriteLine(Math.Max(equalsWordsAtStart,equalWordsAtEnd));
        }
    }
}
