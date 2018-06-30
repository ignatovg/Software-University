using System;
using System.Linq;

namespace P02_KnightGame
{
    class Program
    {
        public static char[,]matrix;

        static void Main(string[] args)
        {
           int n = int.Parse(Console.ReadLine());
            matrix = new char[n,n];

            for (int row = 0; row < n; row++)
            {
                var rowInput = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }

            int amountOfKilled = 0;
            

            while (true)
            {
                int maxKillsPerKnight = KillKnight(matrix);
                if (maxKillsPerKnight == 0)
                {
                    break;
                }
                amountOfKilled++;
              
            }
            Console.WriteLine(amountOfKilled);
        }

        private static int KillKnight(char[,] matrix)
        {
            int maxKills = 0;
            int knigthRow = 0;
            int knightCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'K')
                    {
                        int kills = KillsPerKnigth(row, col);

                        if (maxKills < kills)
                        {
                            maxKills = kills;
                            knigthRow = row;
                            knightCol = col;
                        }
                    }
                }
            }
            if (maxKills != 0)
            {
                matrix[knigthRow, knightCol] = '0';
            }
            
            return maxKills;
        }

        private static int KillsPerKnigth(int row, int col)
        {
            int killKnights = 0;

            killKnights += MoveRightUp(row, col);
            killKnights += MoveRightDown(row, col);
            killKnights += MoveLeftUp(row, col);
            killKnights += MoveLeftDown(row, col);

            return killKnights;
        }

        private static int MoveLeftDown(int currentRow, int currentCol)
        {
            int finalRow = currentRow + 1;
            int finalCol = currentCol - 2;

            if (IsInMatrix(finalRow, finalCol))
            {
                if (matrix[finalRow, finalCol] == 'K')
                {
                    return 1;
                }
            }
            return 0;
        }

        private static int MoveLeftUp(int currentRow, int currentCol)
        {
            int finalRow = currentRow - 1;
            int finalCol = currentCol - 2;

            if (IsInMatrix(finalRow, finalCol))
            {
                if (matrix[finalRow, finalCol] == 'K')
                {
                    return 1;
                }
            }
            return 0;
        }

        private static int MoveRightDown(int currentRow, int currentCol)
        {
            int finalRow = currentRow + 1;
            int finalCol = currentCol + 2;

            if (IsInMatrix(finalRow, finalCol))
            {
                if (matrix[finalRow, finalCol] == 'K')
                {
                    return 1;
                }
            }
            return 0;
        }

        private static int MoveRightUp(int currentRow, int currentCol)
        {
            int finalRow = currentRow - 1;
            int finalCol = currentCol + 2;

            if (IsInMatrix(finalRow, finalCol))
            {
                if (matrix[finalRow, finalCol] == 'K')
                {
                    return 1;
                }
            }
            return 0;
        }

        private static bool IsInMatrix(int row,int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        public static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
