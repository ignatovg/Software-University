using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03._1.FoldAndSum
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int k = numbers.Length / 4;

            int[] leftArr = numbers.Take(k).ToArray();
            int[] rigthArr = numbers.Skip(3 * k).Take(k).ToArray();

            Array.Reverse(leftArr);
            Array.Reverse(rigthArr);

            int[] middleArr = numbers.Skip(k).Take(2 * k).ToArray();

            int[] result=new int[k*2];

            for (int i = 0; i < k; i++)
            {
                result[i] = middleArr[i] + leftArr[i];
                result[i + k] = middleArr[i + k] + rigthArr[i];
            }
            Console.WriteLine(string.Join(" ",result));
        }
    }
}
