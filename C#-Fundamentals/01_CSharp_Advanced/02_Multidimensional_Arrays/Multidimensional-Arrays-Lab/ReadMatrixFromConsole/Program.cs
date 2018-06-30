using System;

namespace ReadMatrixFromConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of the rows: ");
            int rows = int.Parse(Console.ReadLine());

            Console.Write("Enter the number of the colums: ");
            int colums = int.Parse(Console.ReadLine());

            int[,] matrix = new int[rows,colums];

            Console.WriteLine("Enter the cells of the matrix:");

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < colums; col++)
                {
                    Console.Write($"matrix[{row},{col}] = ");
                    matrix[row,col] =int.Parse(Console.ReadLine());
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
