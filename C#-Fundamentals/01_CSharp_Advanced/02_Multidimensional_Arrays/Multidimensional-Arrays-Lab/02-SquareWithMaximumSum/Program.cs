using System;
using System.Linq;

namespace _02_SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowsAndColums = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[,] matrix = new int[rowsAndColums[0],rowsAndColums[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var rowsInput = Console.ReadLine()
                    .Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowsInput[col];
                }
            }
            int bestSum = int.MinValue;
            int besRow = 0;
            int bestCol = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                    if (sum > bestSum)
                    {
                        bestSum = sum;
                        besRow = row;
                        bestCol = col;
                    }
                }
            }
            Console.WriteLine($"{matrix[besRow,bestCol]} {matrix[besRow,bestCol+1]}");
            Console.WriteLine($"{matrix[besRow+1,bestCol]} {matrix[besRow+1,bestCol+1]}");
            Console.WriteLine($"{bestSum}");
        }
    }
}
