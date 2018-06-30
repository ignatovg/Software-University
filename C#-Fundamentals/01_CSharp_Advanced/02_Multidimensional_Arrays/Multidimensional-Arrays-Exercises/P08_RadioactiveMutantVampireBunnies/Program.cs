using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace P08_RadioactiveMutantVampireBunnies
{
    class Program
    {
        private static int rowPCoordinate;
        private static int columnPCoorinate;
        private static bool IsOut = false;
        private static bool IsDead = false;

        static void Main(string[] args)
        {
            int[] rowAndColum = Console.ReadLine().Split(new string[] {" "},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            char[,] matrix = new char[rowAndColum[0], rowAndColum[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var rowsInput = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowsInput[col];
                    if (rowsInput[col] == 'P')
                    {
                        rowPCoordinate = row;
                        columnPCoorinate = col;
                    }
                }
            }
            char[] commandArgs = Console.ReadLine().ToCharArray();

            for (int i = 0; i < commandArgs.Length; i++)
            {
                switch (commandArgs[i])
                {
                    case 'U':
                        matrix = MoveUp(rowPCoordinate, columnPCoorinate, matrix);
                        break;
                    case 'D':
                        matrix = MoveDown(rowPCoordinate, columnPCoorinate, matrix);
                        break;
                    case 'L':
                        matrix = MoveLeft(rowPCoordinate, columnPCoorinate, matrix);
                        break;
                    case 'R':
                        matrix = MoveRight(rowPCoordinate, columnPCoorinate, matrix);
                        break;
                }


                List<int[]> items = new List<int[]>();
                
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'B')
                        {
                            items.Add(new int[2]);
                            int[] ar = { row, col };
                            items.Add(ar);
                        }
                    }
                }

                foreach (var item in items)
                {
                    int row = item[0];
                    int col = item[1];

                    if (matrix[row, col] == 'B')
                    {
                        matrix = PopulateBunny(row, col, matrix);
                        
                    }
                }

                if (IsDead)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"dead: {rowPCoordinate} {columnPCoorinate}");
                    Environment.Exit(0);
                }
                else if (IsOut)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"won: {rowPCoordinate} {columnPCoorinate}");
                    Environment.Exit(0);
                }
            }
        }

        private static char[,] MoveRight(int row, int col, char[,] matrix)
        {
            if (columnPCoorinate == matrix.GetLength(1)-1)
            {
                matrix[row, col] = '.';
                IsOut = true;
                return matrix;
            }
            if (matrix[row, col + 1] == 'B')
            {
                matrix[row, col] = '.';
                IsDead = true;
                return matrix;
            }
            matrix[row, col + 1] = 'P';
            matrix[row, col] = '.';
            columnPCoorinate = col + 1;

           
            return matrix;
        }

        private static char[,] MoveLeft(int row, int col, char[,] matrix)
        {
            if (columnPCoorinate == 0)
            {
                matrix[row, col] = '.';
                IsOut = true;
                return matrix;
            }
            if (matrix[row, col - 1] == 'B')
            {
                matrix[row, col] = '.';
                IsDead = true;
                return matrix;
            }
            matrix[row, col - 1] = 'P';
            matrix[row, col] = '.';
            columnPCoorinate = col - 1;

           
            return matrix;
        }

        private static char[,] MoveDown(int row, int col, char[,] matrix)
        {
            if (rowPCoordinate == matrix.GetLength(0) - 1)
            {
                matrix[row, col] = '.';
                IsOut = true;
                return matrix;
            }
            if (matrix[row + 1, col] == 'B')
            {
                matrix[row, col] = '.';
                IsDead = true;
                return matrix;
            }
            matrix[row + 1, col] = 'P';
            matrix[row, col] = '.';
            rowPCoordinate = row - 1;

            
            return matrix;
        }

        private static char[,] PopulateBunny(int row, int col, char[,] matrix)
        {

            //right
            if (col + 1 != matrix.GetLength(1))
            {
                if (matrix[row, col + 1] == 'P')
                {
                    matrix[row, col + 1] = 'B';
                    IsDead = true;
                }
                else
                {
                    matrix[row, col + 1] = 'B';
                }
            }
            // left
            if (col - 1 != -1)
            {
                if (matrix[row, col - 1] == 'P')
                {
                    matrix[row, col - 1] = 'B';
                    IsDead = true;
                }
                else
                {
                    matrix[row, col - 1] = 'B';
                }
            }
            //down
            if (row + 1 != matrix.GetLength(0))
            {
                if (matrix[row + 1, col] == 'P')
                {
                    matrix[row + 1, col] = 'B';
                    IsDead = true;
                }
                else
                {
                    matrix[row + 1, col] = 'B';
                }
            }
            //up
            if (row - 1 != -1)
            {
                if (matrix[row - 1, col] == 'P')
                {
                    matrix[row - 1, col] = 'B';
                    IsDead = true;
                }
                else
                {
                    matrix[row - 1, col] = 'B';
                }
            }
            return matrix;
        }

        private static char[,] MoveUp(int rowP, int colP, char[,] matrix)
        {
            if (rowPCoordinate == 0)
            {
                matrix[rowP, colP] = '.';
                IsOut = true;
                return matrix;
            }
            if (matrix[rowP - 1, colP] == 'B')
            {
                matrix[rowP, colP] = '.';
                IsDead = true;
                return matrix;
            }
            matrix[rowP - 1, colP] = 'P';
            matrix[rowP, colP] = '.';
            rowPCoordinate = rowP - 1;
            
            return matrix;
        }

        private static void PrintMatrix(char[,] matrix)
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
