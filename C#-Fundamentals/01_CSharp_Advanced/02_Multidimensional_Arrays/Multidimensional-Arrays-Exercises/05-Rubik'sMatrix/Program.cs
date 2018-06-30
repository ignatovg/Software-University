using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Rubik_sMatrix
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
                    matrix[row, col] = number;
                }
            }

            int commandCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandCount; i++)
            {
                ParseCommand();
            }

            RearrangeMatrix();
        }

        private static void RearrangeMatrix()
        {
            int expected = 1;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < colums; col++)
                {
                    if (matrix[row, col] == expected)
                    {
                        Console.WriteLine($"No swap required");
                    }
                    else
                    {
                        for (int r = 0; r < row; r++)
                        {
                            for (int c = 0; c < colums; c++)
                            {
                                if (matrix[r, c] == expected)
                                {
                                    int temp = matrix[row, col];

                                    matrix[row, col] = matrix[r, c];
                                    matrix[r, c] = temp;
                                    Console.WriteLine($"Swap ({row}, {col}) with ({r}, {c})");
                                    
                                }
                            }
                        }
                    }
                    expected++;
                }
            }
        }

        private static void ParseCommand()
        {
            string[] commandArgs = Console.ReadLine().Split(' ');

            string command = commandArgs[1];
            int index = int.Parse(commandArgs[0]);
            int rotations = int.Parse(commandArgs[2]);

            switch (command)
            {
                case "up":
                    MoveColumn(index, rows - rotations);
                    break;
                case "down":
                    MoveColumn(index, rotations);
                    break;
                case "left":
                    MoveRow(index, colums - rotations);
                    break;
                case "rigth":
                    MoveRow(index, rotations);
                    break;
            }
        }

        private static void MoveRow(int index, int rotations)
        {
            rotations %= colums;
            
            int[] tempArray = new int[colums];

            for (int col = 0; col < colums; col++)
            {
                int replacemnetIndex = col + rotations;

                replacemnetIndex %= colums;

                tempArray[replacemnetIndex] = matrix[index, col];
            }

            for (int col = 0; col < colums; col++)
            {
                matrix[index, col] = tempArray[col];
            }
        }

        private static void MoveColumn(int index, int rotations)
        {
            rotations %= rows;

            int[] tempArray = new int[rows];

            for (int row = 0; row < colums; row++)
            {
                int replacemnetIndex = row + rotations;

                replacemnetIndex %= rows;

                tempArray[replacemnetIndex] = matrix[index, row];
            }

            for (int row = 0; row < rows; row++)
            {
                matrix[row, index] = tempArray[row];
            }

        }
    }
}
