using System;
using System.Linq;

namespace _03_GroupNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[][] jaggedArray = new int[3][];

            jaggedArray[0] = input.Where(n =>Math.Abs(n) % 3 == 0).ToArray();
            jaggedArray[1] = input.Where(n =>Math.Abs(n) % 3 == 1).ToArray();
            jaggedArray[2] = input.Where(n =>Math.Abs(n) % 3 == 2).ToArray();

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write($"{jaggedArray[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
