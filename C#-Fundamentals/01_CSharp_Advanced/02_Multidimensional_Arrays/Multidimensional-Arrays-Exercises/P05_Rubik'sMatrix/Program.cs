using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05_Rubik_sMatrix
{
    class Program
    {
        private static int[,] matrix;
        private static int rows;
        private static int colums;

        static void Main(string[] args)
        {
            int[] demensions = Console.ReadLine()
                .Split(' ').Select(int.Parse).ToArray();

            matrix = new int[demensions[0], demensions[1]];
            rows = demensions[0];
            colums = demensions[1];

            int number = 1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = number++;
                }
            }
            //print
           // PrintMatrix();

            int commandCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandCount; i++)
            {
                ParseCommand();
               // Console.WriteLine("new matrix");
               // PrintMatrix();
            }

            RearrangeMatrix();
        }

        private static void RearrangeMatrix()
        {
            int originalPosition = 1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (originalPosition == matrix[row, col])
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        bool isSwapped = false;
                        for (int r = 0; r < matrix.GetLength(0); r++)
                        {
                            for (int c = 0; c < matrix.GetLength(1); c++)
                            {
                                if (originalPosition == matrix[r, c])
                                {
                                    Console.WriteLine($"Swap ({row}, {col}) with ({r}, {c})");

                                    int temp = matrix[row, col];
                                    matrix[row, col] = originalPosition;
                                    matrix[r, c] = temp;

                                    isSwapped = true;
                                    break;
                                }
                            }
                            if (isSwapped)
                            {
                                break;
                            }
                        }
                    }
                    originalPosition++;
                }
            }
        }

        private static void ParseCommand()
        {
            string[] commandArgs = Console.ReadLine().Split(' ');
            int onRowOrCol = int.Parse(commandArgs[0]);
            string direction = commandArgs[1];
            int moves = int.Parse(commandArgs[2]);

            switch (direction)
            {
                case "up":
                    MoveUp(onRowOrCol, moves);
                    break;
                case "down":
                    MoveDown(onRowOrCol,moves);
                    break;
                case "left":
                    MoveLeft(onRowOrCol, moves);
                    break;
                case "right":
                    MoveRight(onRowOrCol, moves);
                    break;
            }
        }

        private static void MoveRight(int onRowOrCol, int moves)
        {
            int reminder = moves % colums;

            if (reminder != 0)
            {
                while (reminder != 0)
                {
                    int temp = matrix[onRowOrCol, matrix.GetLength(1) - 1];

                    for (int col = matrix.GetLength(1) - 1; col > 0; col--)
                    {
                        matrix[onRowOrCol, col] = matrix[onRowOrCol, col - 1];
                    }
                    matrix[onRowOrCol, 0] = temp;

                    reminder--;
                }
            }
        }

        private static void MoveLeft(int onRowOrCol, int moves)
        {
            int reminder = moves % colums;

            if (reminder != 0)
            {
                while (reminder != 0)
                {
                    int temp = matrix[onRowOrCol, 0];
                    for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                    {
                        matrix[onRowOrCol, col] = matrix[onRowOrCol, col + 1];
                    }
                    matrix[onRowOrCol, matrix.GetLength(1) - 1] = temp;

                    reminder--;
                }
            }
        }

        private static void MoveUp(int onRowOrCol, int moves)
        {
            int remainder = moves % rows;
            if (remainder != 0)
            {
                while (remainder != 0)
                {
                    int temp = matrix[0, onRowOrCol];
                    for (int row = 0; row < matrix.GetLength(0) - 1; row++)
                    {
                        matrix[row, onRowOrCol] = matrix[row + 1, onRowOrCol];
                    }
                    matrix[matrix.GetLength(0) - 1, onRowOrCol] = temp;

                    remainder--;
                }
            }
        }

        private static void MoveDown(int onRowOrCol, int moves)
        {
            int remainder = moves % rows;
            if (remainder != 0)
            {
                while (remainder != 0)
                {

                    int temp = matrix[matrix.GetLength(0) - 1, onRowOrCol];

                    for (int row = matrix.GetLength(0) - 1; row > 0; row--)
                    {
                        matrix[row, onRowOrCol] = matrix[row - 1, onRowOrCol];
                    }
                    matrix[0, onRowOrCol] = temp;

                    remainder--;
                }
            }
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
