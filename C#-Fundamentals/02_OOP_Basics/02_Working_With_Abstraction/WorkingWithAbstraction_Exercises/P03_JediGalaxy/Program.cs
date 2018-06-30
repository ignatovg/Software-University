using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            //Create Matrix
            int[] dimestions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = CreateMatrix(dimestions);


            string command;
            long sum = 0;
            while ((command= Console.ReadLine()) != "Let the Force be with you")
            {
                int[] ivoCoords = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int[] evilCoords = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                matrix = MoveEvil(evilCoords, matrix);

                sum = MoveIvo(ivoCoords, matrix, sum);
                
            }

            Console.WriteLine(sum);

        }

        private static long MoveIvo(int[] ivoCoords, int[,] matrix, long sum)
        {
            int ivoRow = ivoCoords[0];
            int ivoCol = ivoCoords[1];

            while (ivoRow >= 0 && ivoCol < matrix.GetLength(1))
            {
                if (IsInside(matrix, ivoRow, ivoCol))
                {
                    sum += matrix[ivoRow, ivoCol];
                }

                ivoCol++;
                ivoRow--;
            }
            return sum;
        }

        private static int[,] MoveEvil(int[] evilCoords, int[,] matrix)
        {
            int evilRow = evilCoords[0];
            int evilCol = evilCoords[1];

            while (evilRow >= 0 && evilCol >= 0)
            {
                if (IsInside(matrix, evilRow, evilCol))
                {
                    matrix[evilRow, evilCol] = 0;
                }
                evilRow--;
                evilCol--;
            }
            return matrix;
        }

        private static bool IsInside(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        private static int[,] CreateMatrix(int[] dimestions)
        {
            int rowX = dimestions[0];
            int colY = dimestions[1];

            int[,] matrix = new int[rowX, colY];

            int value = 0;
            for (int row = 0; row < rowX; row++)
            {
                for (int col = 0; col < colY; col++)
                {
                    matrix[row, col] = value++;
                }
            }
            return matrix;
        }
    }
}
