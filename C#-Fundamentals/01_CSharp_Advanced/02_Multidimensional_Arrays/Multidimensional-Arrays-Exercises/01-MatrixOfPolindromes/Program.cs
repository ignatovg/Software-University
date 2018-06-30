using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_MatrixOfPolindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowsAndColums = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            string[,] matrix = new string[rowsAndColums[0], rowsAndColums[1]];
            StringBuilder word = new StringBuilder();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    word.Append(alphabet[row]);
                    word.Append(alphabet[row + col]);
                    word.Append(alphabet[row]);
                    matrix[row, col] = word.ToString();
                    word.Clear();
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row,col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
