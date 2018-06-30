using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_2x2SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowsAndCols = Console.ReadLine()
                .Split(' ').Select(int.Parse).ToArray();
            string[,] matrix = new String[rowsAndCols[0],rowsAndCols[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] inputCharacters = Console.ReadLine().Split(' ');
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputCharacters[col];
                }
            }
            int numOfEqualSqrt = 0;
            for (int row = 0; row < matrix.GetLength(0)-1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] && matrix[row, col] == matrix[row + 1, col] &&
                        matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        numOfEqualSqrt++;
                    }
                }
            }
            Console.WriteLine(numOfEqualSqrt);
        }
    }
}
