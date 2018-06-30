using System;

namespace DemoBook
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] intMatrix = new int[3,4];

            int[,] matrix =
            {
                {1,2,3,4 },
                {5,6,4,7 }
            };

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }

            int[][] jaggedArray = new int[2][];
            jaggedArray[0] = new int[4];
            jaggedArray[1] = new int[2];
        }
    }
}
