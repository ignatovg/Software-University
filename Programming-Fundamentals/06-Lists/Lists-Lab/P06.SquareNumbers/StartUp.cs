using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06.SquareNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            List<int> squareNumbers=new List<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                int num = numbers[i];
                if (Math.Sqrt(num) == (int) Math.Sqrt(num))
                {
                    squareNumbers.Add(num);
                }
            }
            squareNumbers.Sort((a,b) => b.CompareTo(a));
            Console.WriteLine(string.Join(" ",squareNumbers));
        }
    }
}
