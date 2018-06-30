using System;
using System.Linq;
using System.Security.Cryptography;

namespace P01_DangerousFloor
{
    class Program
    {
        public static string[,] matrix;
        static void Main(string[] args)
        {
             matrix = new string[8,8];

            for (int row = 0; row < 8; row++)
            {
                string[] readRow = Console.ReadLine().Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
                    
                for (int col = 0; col < 8; col++)
                {
                    matrix[row, col] = readRow[col];
                }
            }
            string move = string.Empty;
            while ((move=Console.ReadLine())!= "END")
            {
                if (!IsCheckPassed(move))
                {
                    continue;
                }
                string[] tokens = move.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                string figure = tokens[0][0].ToString();
                string curretPosition = tokens[0][1].ToString() + tokens[0][2].ToString();
                string finalPosition = tokens[1];

                MoveFigure(figure,curretPosition,finalPosition);
            }
        }

        private static bool IsCheckPassed(string move)
        {
            string[] tokens = move.Split(new char[] {'-'}, StringSplitOptions.RemoveEmptyEntries);
            string figure = tokens[0][0].ToString();
            string curretPosition = tokens[0][1].ToString()+tokens[0][2].ToString();
            string finalPosition = tokens[1];

            if (!IsValidCurrentPosition(figure, curretPosition))
            {
                Console.WriteLine("There is no such a piece!");
                return false;
            }
            if (!IsInMatrix(finalPosition))
            {
                Console.WriteLine("Move go out of board!");
                return false;
            }
            if (!IsValidMove(figure, curretPosition, finalPosition))
            {
                Console.WriteLine("Invalid move!");
                return false;
            }
            
            return true;
        }

        private static bool IsValidMove(string figure, string curretPosition, string finalPosition)
        {
            switch (figure)
            {
                case "K":
                    return IsValidMoveKing(curretPosition, finalPosition);
                    
                case "R":
                    return IsValidMoveRook(curretPosition, finalPosition);
                    
                case "B":
                    return IsValidMoveBishop(curretPosition, finalPosition);
                   
                case "Q":
                    return IsValidMoveRook(curretPosition, finalPosition) || IsValidMoveBishop(curretPosition, finalPosition);
                    break;
                case "P":
                    return IsValidMovePawn(curretPosition, finalPosition);
            }
            return false;
        }

        private static bool IsValidMovePawn(string curretPosition, string finalPosition)
        {
            int currentRow = int.Parse(curretPosition[0].ToString());
            int currentCol = int.Parse(curretPosition[1].ToString());

            int finalRow = int.Parse(finalPosition[0].ToString());
            int finalCol = int.Parse(finalPosition[1].ToString());

            if (IsInMatrix(finalPosition))
            {
                if (currentRow-1==finalRow && currentCol==finalCol)
                {
                    if (IsEmptyPosition(finalRow,finalCol))
                    {
                      //  Console.WriteLine($"i was there ->  {finalPosition} !!!");
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool IsValidMoveBishop(string curretPosition, string finalPosition)
        {
            int currentRow = int.Parse(curretPosition[0].ToString());
            int currentCol = int.Parse(curretPosition[1].ToString());

            int finalRow = int.Parse(finalPosition[0].ToString());
            int finalCol = int.Parse(finalPosition[1].ToString());

            if (IsInMatrix(finalPosition))
            {
                if (currentRow < finalRow && currentCol < finalCol)
                {
                    int cRow = currentRow;
                    int cCol = currentCol;
                    while (cRow != finalRow && cCol!=finalCol)
                    {
                        cRow++;
                        cCol++;
                        if (!IsEmptyPosition(cRow, cCol))
                        {
                            return false;
                        }
                    }
                   // Console.WriteLine($"i was there ->  {finalRow} {finalCol} !!!");
                    return true;
                }
                if (currentRow > finalRow && currentCol < finalCol)
                {
                    int cRow = currentRow;
                    int cCol = currentCol;
                    while (cRow != finalRow && cCol != finalCol)
                    {
                        cRow--;
                        cCol++;
                        if (!IsEmptyPosition(cRow, cCol))
                        {
                            return false;
                        }
                    }
                  //  Console.WriteLine($"i was there ->  {finalRow} {finalCol} !!!");
                    return true;
                }
                if (currentRow < finalRow && currentCol > finalCol)
                {
                    int cRow = currentRow;
                    int cCol = currentCol;
                    while (cRow != finalRow && cCol != finalCol)
                    {
                        cRow++;
                        cCol--;
                        if (!IsEmptyPosition(cRow, cCol))
                        {
                            return false;
                        }
                    }
                  //  Console.WriteLine($"i was there ->  {finalRow} {finalCol} !!!");
                    return true;
                }
                if (currentRow > finalRow && currentCol > finalCol)
                {
                    int cRow = currentRow;
                    int cCol = currentCol;
                    while (cRow != finalRow && cCol != finalCol)
                    {
                        cRow--;
                        cCol--;
                        if (!IsEmptyPosition(cRow, cCol))
                        {
                            return false;
                        }
                    }
                   // Console.WriteLine($"i was there ->  {finalRow} {finalCol} !!!");
                    return true;
                }
                
            }
            return false;
        }

        private static bool IsValidMoveRook(string curretPosition, string finalPosition)
        {
            int currentRow = int.Parse(curretPosition[0].ToString());
            int currentCol = int.Parse(curretPosition[1].ToString());

            int finalRow = int.Parse(finalPosition[0].ToString());
            int finalCol = int.Parse(finalPosition[1].ToString());

            if (IsInMatrix(finalPosition))
            {
                if (currentRow == finalRow || currentCol == finalCol)
                {
                    if (currentCol<finalCol)
                    {
                        for (int col = currentCol+1; col <= finalCol; col++)
                        {
                            if (!IsEmptyPosition(finalRow, col))
                            {
                                return false;
                            }
                        }
                    }
                    else if (currentCol > finalCol)
                    {
                        for (int col = currentCol-1; col >= finalCol; col--)
                        {
                            if (!IsEmptyPosition(finalRow, col))
                            {
                                return false;
                            }
                        }
                    }
                    if (currentRow < finalRow)
                    {
                        for (int row = currentRow + 1; row <= finalRow; row++)
                        {
                            if (!IsEmptyPosition(row, finalCol))
                            {
                                return false;
                            }
                        }
                    }
                    else if (currentRow > finalRow)
                    {
                        for (int row = currentRow - 1; row >= finalRow; row--)
                        {
                            if (!IsEmptyPosition(row, finalCol))
                            {
                                return false;
                            }
                        }
                    }
                   // Console.WriteLine($"I was there {finalRow} {finalCol}");
                    return true;
                }
            }
            return false;
        }

        private static bool IsValidMoveKing(string curretPosition, string finalPosition)
        {
            int currentRow = int.Parse(curretPosition[0].ToString());
            int currentCol = int.Parse(curretPosition[1].ToString());

            int finalRow = int.Parse(finalPosition[0].ToString());
            int finalCol = int.Parse(finalPosition[1].ToString());

            if (IsInMatrix(finalPosition))
            {
                if (currentRow+1>=finalRow && currentCol-1>=finalCol || currentRow-1<=finalRow && currentCol+1>=finalCol)
                {
                    if (IsEmptyPosition(finalRow,finalCol))
                    {
                       // Console.WriteLine($"i was there ->  {finalPosition} !!!");
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool IsInMatrix(string finalPosition)
        {
            int finalRow = int.Parse(finalPosition[0].ToString());
            int finalCol = int.Parse(finalPosition[1].ToString());

            return finalRow >= 0 && finalRow < 8 && finalCol >= 0 && finalCol < 8;
        }

        private static void MoveFigure(string figure,string curretPosition, string finalPosition)
        {

            int finalRow = int.Parse(finalPosition[0].ToString());
            int finalCol = int.Parse(finalPosition[1].ToString());

            if (IsEmptyPosition(finalRow,finalCol))
            {
                int currentRow = int.Parse(curretPosition[0].ToString());
                int currentCol = int.Parse(curretPosition[1].ToString());


                matrix[currentRow, currentCol] = "x";
                matrix[finalRow, finalCol] = figure;
            }
        }

        private static bool IsEmptyPosition(int row, int col)
        {

            if (matrix[row, col] != "x")
            {
                return false;
            }
            return true;
        }

        private static bool IsValidCurrentPosition(string figure, string curretPosition)
        {
            int row = int.Parse(curretPosition[0].ToString());
            int col = int.Parse(curretPosition[1].ToString());

            if (matrix[row, col] != figure)
            {
                return false;
            }
            return true;
        }
    }
}
