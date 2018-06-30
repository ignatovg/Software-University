using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowsAndColums = Console.ReadLine()
                .Split(new string[]{" "},StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[,] matrix = new int[rowsAndColums[0], rowsAndColums[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var rowsInput = Console.ReadLine()
                    .Split(new string[]{" "},StringSplitOptions.RemoveEmptyEntries) 
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

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row,col + 2] + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col +2] + matrix[row+2,col] + matrix[row+2,col+1]+matrix[row+2,col+2];
                    if (sum > bestSum)
                    {
                        bestSum = sum;
                        besRow = row;
                        bestCol = col;
                    }
                }
            }
            Console.WriteLine($"Sum = {bestSum}");
            Console.WriteLine($"{matrix[besRow, bestCol]} {matrix[besRow, bestCol + 1]} {matrix[besRow,bestCol + 2]}");
            Console.WriteLine($"{matrix[besRow + 1, bestCol]} {matrix[besRow + 1, bestCol + 1]} {matrix[besRow + 1,bestCol + 2]}");
            Console.WriteLine($"{matrix[besRow + 2, bestCol]} {matrix[besRow + 2, bestCol + 1]} {matrix[besRow + 2,bestCol + 2]}");
        }
    }
    
}
