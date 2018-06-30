using System;
using System.Linq;

namespace Bojo_DangerousFloor
{
    class Program
    {
        private static char[][] board;

        static void Main(string[] args)
        {
            board = new char[8][];
            for (int row = 0; row < board.Length; row++)
            {
                board[row] = Console.ReadLine()
                    .Split(',')
                    .Select(char.Parse).ToArray();
            }
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                char figureType = command[0];
                int startingRow = int.Parse(command[1].ToString());
                int startingCol = int.Parse(command[2].ToString());
                int targetRow = int.Parse(command[4].ToString());
                int targetCol = int.Parse(command[5].ToString());

                bool figureExists = FigureExists(figureType, startingRow, startingCol);
                if (!figureExists)
                {
                    Console.WriteLine("There is no such a piece!");
                    continue;
                }

                if (!IsMoveValid(figureType, startingRow, startingCol, targetRow, targetCol))
                {
                    Console.WriteLine("Invalid move!");
                    continue;
                }
                if (!OutOfBoard(targetRow, targetCol))
                {
                    Console.WriteLine("Move go out of board!");
                    continue;
                }
                board[targetRow][targetCol] = figureType;
                board[startingRow][startingCol] = 'x';

            }
        }



        private static bool OutOfBoard(int targetRow, int targetCol)
        {
            bool validRow = targetRow >= 0 && targetRow <= 7;
            bool validCol = targetCol >= 0 && targetCol <= 7;

            return validRow && validCol;
        }

        private static bool IsMoveValid(char figureType, int startingRow, int startingCol, int targetRow, int targetCol)
        {
            switch (figureType)
            {
                case 'P':
                    return ValidPawnMove(startingRow, startingCol, targetRow, targetCol);
                    break;
                case 'R':
                    return ValidStraightMove(startingRow, startingCol, targetRow, targetCol);
                case 'B':
                    return ValidDiagonalMove(startingRow, startingCol, targetRow, targetCol);
                case 'Q':
                    return ValidStraightMove(startingRow, startingCol, targetRow, targetCol) ||
                        ValidDiagonalMove(startingRow, startingCol, targetRow, targetCol);
                case 'K':
                    return ValidKingMove(startingRow, startingCol, targetRow, targetCol);
                default:
                    throw new NotImplementedException();
            }
        }

        private static bool ValidKingMove(int startingRow, int startingCol, int targetRow, int targetCol)
        {
            bool validRow = Math.Abs(startingRow - targetRow) == 1 ||
                            Math.Abs(startingRow - targetRow) == 0;
            bool validCol = Math.Abs(startingCol - targetCol) == 1 ||
                            Math.Abs(startingCol - targetCol) == 0;
            return validRow && validCol;
        }

        private static bool ValidDiagonalMove(int startingRow, int startingCol, int targetRow, int targetCol)
        {
            return Math.Abs(startingRow - targetRow) == Math.Abs(startingCol - targetCol);
            return startingRow + startingCol == targetRow + targetCol;
        }

        private static bool ValidStraightMove(int startingRow, int startingCol, int targetRow, int targetCol)
        {
            bool sameRow = startingRow == targetRow;
            bool sameCol = startingCol == targetCol;

            return sameRow || sameCol;

        }

        private static bool ValidPawnMove(int startingRow, int startingCol, int targetRow, int targetCol)
        {
            bool validColumn = startingCol == targetCol;
            bool validRow = startingRow - 1 == targetRow;

            return validColumn && validRow;
        }

        private static bool FigureExists(char figureType, int startingRow, int startingCol)
        {
            return board[startingRow][startingCol] == figureType;
        }
    }
}
