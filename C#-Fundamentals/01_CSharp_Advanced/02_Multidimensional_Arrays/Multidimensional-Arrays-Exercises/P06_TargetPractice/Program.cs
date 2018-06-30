using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06_TargetPractice
{
    class Program
    {
        private static char[,] matrix;
        private static int rows;
        private static int colums;

        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split(new string[]{" "},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            rows = dimensions[0];
            colums = dimensions[1];
            matrix = new char[rows, colums];

            string snake = Console.ReadLine();

            int[] shotParameters = Console.ReadLine().Split(new string[]{" "},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            FillMatrix(snake);

            FireShot(shotParameters);
            
            Gravity();

            PrintMatrix();

        }

        private static void Gravity()
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int emptyRows = 0;

                for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
                {
                    if (matrix[row, col] == ' ')
                    {
                        emptyRows++;
                    }
                    else if(emptyRows > 0)
                    {
                        matrix[row + emptyRows, col] = matrix[row, col];
                        matrix[row, col] = ' ';
                    }
                }

            }
        }

        private static void FireShot(int[] shotParameters)
        {
            int row = shotParameters[0];
            int column = shotParameters[1];
            int radius = shotParameters[2];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    int a = row - r;
                    int b = column - c;
                    double distance = Math.Sqrt(a * a + b * b);

                    if (distance <= radius)
                    {
                        matrix[r, c] = ' ';
                    }
                }
            }
        }

        private static void FillMatrix(string snake)
        {
            int indexOfSnake = 0;
            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                if (row % 2 == 0)
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        if (indexOfSnake == snake.Length)
                        {
                            indexOfSnake = 0;
                        }

                        matrix[row, col] = snake[indexOfSnake];

                        indexOfSnake++;
                    }
                }
                else
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (indexOfSnake == snake.Length)
                        {
                            indexOfSnake = 0;
                        }

                        matrix[row, col] = snake[indexOfSnake];

                        indexOfSnake++;
                    }
                }
            }
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
