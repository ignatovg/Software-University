using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P09_Crossfire
{
    class Program
    {
        private static List<List<int>> matrix;

        static void Main(string[] args)
        {
            //Runtime error.
            int[] rowAndCol = Console.ReadLine().Split(new string[]{" "},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            matrix = new List<List<int>>();

            int n = 1;

            for (int row = 0; row < rowAndCol[0]; row++)
            {
                matrix.Add(new List<int>());
                for (int col = 0; col < rowAndCol[1]; col++)
                {
                    matrix[row].Add(n);
                    n++;
                }
            }
            string command = Console.ReadLine();
            while (command != "Nuke it from orbit")
            {
                BombMatrix(command, matrix);
                RemoveMinusOne();

                command = Console.ReadLine();
            }
            PrintMatrix(matrix);
        }

        private static void RemoveMinusOne()
        {
            for (int row = 0; row < matrix.Count; row++)
            {
                matrix[row].RemoveAll(a => a == -1);
            }
        }

        private static void BombMatrix(string command, List<List<int>> matrix)
        {
            int row = command.Split(' ').Select(int.Parse).ToArray()[0];
            int col = command.Split(' ').Select(int.Parse).ToArray()[1];
            int radius = command.Split(' ').Select(int.Parse).ToArray()[2];

            matrix[row][col] = -1;
            MoveLeft(row, col, radius);
            MoveRight(row, col, radius);
            MoveUp(row, col, radius);
            MoveDown(row, col, radius);

        }

        private static void MoveDown(int row, int col, int radius)
        {
            //down
            while (radius != 0)
            {
                row++;
                if (row == matrix.Count)
                {
                    break;
                }
                if (matrix[row].Count < col)
                {
                    row++;
                    radius--;
                    continue;
                }
                matrix[row][col] = -1;
                radius--;
            }
        }

        private static void MoveUp(int row, int col, int radius)
        {
            //up
            while (radius != 0)
            {
                row--;
                if (row == -1)
                {
                    break;
                }
                if (matrix[row].Count < col)
                {
                    row++;
                    radius--;
                    continue;
                }

                matrix[row][col] = -1;
                radius--;
            }
        }

        private static void MoveRight(int row, int col, int radius)
        {
            //right
            while (radius != 0)
            {
                col++;
                if (col == matrix[row].Count)
                {
                    break;
                }
                matrix[row][col] = -1;
                radius--;
            }
        }

        private static void MoveLeft(int row, int col, int radius)
        {
            //left
            while (radius != 0)
            {
                col--;
                if (col == -1)
                {
                    break;
                }
                matrix[row][col] = -1;
                radius--;
            }
        }

        private static void PrintMatrix(List<List<int>> matrix)
        {
            Console.WriteLine();
            for (int row = 0; row < matrix.Count; row++)
            {
                for (int col = 0; col < matrix[row].Count; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
