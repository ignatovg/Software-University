using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01._1.LargestCommonEnd
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] firstArr = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string[] secondArr = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int leftCount = FindMaxCommonItems(firstArr, secondArr);
            Array.Reverse(firstArr);
            Array.Reverse(secondArr);
            int rightCount = FindMaxCommonItems(firstArr, secondArr);

            Console.WriteLine(Math.Max(leftCount,rightCount));
        }

        private static int FindMaxCommonItems(string[] firstArr, string[] secondArr)
        {
            int lenght = Math.Min(firstArr.Length, secondArr.Length);
            int count = 0;
            for (int i = 0; i < lenght; i++)
            {
                if (firstArr[i] == secondArr[i])
                {
                    count++;
                }
                else
                {
                    return count;
                }
            }
            return count;
        }
    }
}
