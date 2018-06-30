using System;

namespace P02_1KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var boardSize = int.Parse(Console.ReadLine());
            char[][] board = new char[boardSize][];
            for (int i = 0; i < boardSize; i++)
            {
                board[i] = Console.ReadLine().ToCharArray();
            }

            int maxRow = 0;
            int maxColumn = 0;
            int maxAttackedPossitions = 0;
            int countOfRemovedKnights = 0;
            do
            {
                if (maxAttackedPossitions > 0)
                {
                    board[maxRow][maxColumn] = '0';
                    maxAttackedPossitions = 0;
                    countOfRemovedKnights++;
                }
                int currentAttackPossition = 0;
                for (int row = 0; row < boardSize; row++)
                {
                    for (int col = 0; col < boardSize; col++)
                    {

                        if (board[row][col] == 'K')
                        {
                            currentAttackPossition = CalculateAttackPossitions(row, col, board);
                            if (currentAttackPossition > maxAttackedPossitions)
                            {
                                maxAttackedPossitions = currentAttackPossition;
                                maxRow = row;
                                maxColumn = col;
                            }
                        }
                    }
                }

            } while (maxAttackedPossitions > 0);
            Console.WriteLine(countOfRemovedKnights);
        }

        static int CalculateAttackPossitions(int row, int column, char[][] board)
        {
            var currentAttackPositions = 0;
            if (IsPositionAttack(row - 2, column - 1, board)) currentAttackPositions++;
            if (IsPositionAttack(row - 2, column + 1, board)) currentAttackPositions++;
            if (IsPositionAttack(row - 1, column - 2, board)) currentAttackPositions++;
            if (IsPositionAttack(row - 1, column + 2, board)) currentAttackPositions++;
            if (IsPositionAttack(row + 1, column - 2, board)) currentAttackPositions++;
            if (IsPositionAttack(row + 1, column + 2, board)) currentAttackPositions++;
            if (IsPositionAttack(row + 2, column - 1, board)) currentAttackPositions++;
            if (IsPositionAttack(row + 2, column + 1, board)) currentAttackPositions++;

            return currentAttackPositions;
            
        }

        static bool IsPositionAttack(int row, int column, char[][] board)
        {
            return IsPossitionWithinBoard(row, column, board.Length)
                   && board[row][column] == 'K';
        }
        static bool IsPossitionWithinBoard(int row, int col, int bordSize)
        {
            return row >= 0 && row < bordSize && col >= 0 && col < bordSize;
        }
    }
}
