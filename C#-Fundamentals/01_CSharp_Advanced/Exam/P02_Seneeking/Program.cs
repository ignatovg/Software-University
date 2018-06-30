using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace P02_Seneeking
{
    class Program
    {
        private static char[][] room;
        static int samRow;
        static int samCol;
        static bool isEnemyFaceHim = false;
        static bool isNikoladzeDied = false;
        static void Main(string[] args)
        {
            int rowIndex = int.Parse(Console.ReadLine());

            room = new char[rowIndex][];

            for (int row = 0; row < rowIndex; row++)
            {
                room[row] = Console.ReadLine().ToCharArray();
            }
            char[] commands = Console.ReadLine().ToCharArray();
            bool isSamDied = false;
            int indexOfComamd = 0;
            
            FindSam();
         
            while (!isSamDied && !isNikoladzeDied)
            {
                if (IsNikoladzeOnTheSameRow())
                {
                    Console.WriteLine($"Nikoladze killed!");
                    isNikoladzeDied = true;

                    PrintMatrix();

                    Environment.Exit(0);
                }
                MoveEnemy();
                if (IsSamOnTheSameRow())
                {
                    if (isEnemyFaceHim)
                    {
                        room[samRow][samCol] = 'X';
                        Console.WriteLine($"Sam died at {samRow}, {samCol}");
                        isSamDied = true;
                        PrintMatrix();

                        Environment.Exit(0);
                    }
                }
               

                MoveSam(commands[indexOfComamd]);
                
               // Console.WriteLine($"Move same");
                //PrintMatrix();

                indexOfComamd++;
             
            }
            
        }

        private static bool IsNikoladzeOnTheSameRow()
        {

            for (int col = 0; col < room[samRow].Length; col++)
            {
                if (room[samRow][col] == 'N')
                {
                    room[samRow][col] = 'X';
                  
                    return true;
                }
            }
            return false;

        }

        private static void MoveSam(char command)
        {
            switch (command)
            {
                case 'L':
                    MoveLeft();
                    break;
                case 'R':
                    MoveRight();
                    break;
                case 'U':
                    MoveUp();
                    break;
                case 'D':
                    MoveDown();
                    break;
                case 'W':
                    break;
            }

        }

        private static void MoveDown()
        {
            if (samRow + 1 == 'd' || samRow + 1 == 'b')
            {
                room[samRow + 1][samCol] = 'S';
                room[samRow][samCol] = '.';

                samRow = samRow + 1;
            }
            else if (samRow + 1 == 'N')
            {
                room[samRow + 1][samCol] = 'X';
                room[samRow][samCol] = '.';

                samRow = samRow + 1;
                isNikoladzeDied = true;
            }
            else
            {
                room[samRow + 1][samCol] = 'S';
                room[samRow][samCol] = '.';

                samRow = samRow + 1;
            }

        }

        private static void MoveUp()
        {
            if (samRow - 1 == 'd' || samRow - 1 == 'b')
            {
                room[samRow - 1][samCol] = 'S';
                room[samRow][samCol] = '.';

                samRow = samRow - 1;
            }
            else if (samRow - 1 == 'N')
            {
                room[samRow - 1][samCol] = 'X';
                room[samRow][samCol] = '.';

                samRow = samRow - 1;

                isNikoladzeDied = true;
            }
            else
            {
                room[samRow - 1][samCol] = 'S';
                room[samRow][samCol] = '.';

                samRow = samRow - 1;
            }

        }

        private static void MoveRight()
        {
            if (samCol + 1 == 'b')
            {
                room[samRow][samCol + 1] = 'S';
                room[samRow][samCol] = '.';

                samCol = samCol + 1;

            }
            else if (samCol + 1 == 'N')
            {
                room[samRow][samCol + 1] = 'X';
                room[samRow][samCol] = '.';

                samCol = samCol + 1;

                isNikoladzeDied = true;
            }
            else
            {
                room[samRow][samCol + 1] = 'S';
                room[samRow][samCol] = '.';

                samCol = samCol + 1;
            }



        }

        private static void MoveLeft()
        {
            if (samCol - 1 == 'd')
            {
                room[samRow][samCol - 1] = 'S';
                room[samRow][samCol] = '.';

                samCol = samCol - 1;
            }
            else if (samCol - 1 == 'N')
            {
                room[samRow][samCol - 1] = 'X';
                room[samRow][samCol] = '.';

                samCol = samCol - 1;
                isNikoladzeDied = true;
            }
            else
            {
                room[samRow][samCol - 1] = 'S';
                room[samRow][samCol] = '.';

                samCol = samCol - 1;
            }


        }


        private static bool IsSamOnTheSameRow()
        {
            // FindSam();

            for (int col = 0; col < room[samRow].Length; col++)
            {
                if (room[samRow][col] == 'b')
                {
                    if (col < samCol)
                    {
                        isEnemyFaceHim = true;
                        return true;
                    }
                    return true;
                }
                else if (room[samRow][col] == 'd')
                {
                    if (samCol < col)
                    {

                        isEnemyFaceHim = true;
                        return true;
                    }
                    return true;
                }
            }
            return false;
        }

        private static void FindSam()
        {
            bool foundedsSam = false;

            for (int row = room.Length - 1; row >= 0; row--)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'S')
                    {
                        samRow = row;
                        samCol = col;
                        foundedsSam = true;
                        break;
                    }
                }
                if (foundedsSam)
                {
                    break;
                }
            }

        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    Console.Write(room[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static void MoveEnemy()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'b')
                    {
                        if (col == room[row].Length - 1)
                        {
                            room[row][col] = 'd';
                          
                        }
                        else
                        {
                            room[row][col] = '.';
                            room[row][col + 1] = 'b';

                        }
                        break;
                    }
                    else if (room[row][col] == 'd')
                    {
                        if (col == 0)
                        {
                            room[row][col] = 'b';
                          
                        }
                        else
                        {
                            room[row][col] = '.';
                            room[row][col - 1] = 'd';
                        }
                        break;
                    }
                }
            }
        }

    }
}
