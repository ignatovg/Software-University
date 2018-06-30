using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace P07_LegoBlocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[][] jaggedArrOne = new string[n][];
            string[][] jaggedArrTwo = new string[n][];
            int numOfCells = 0;
            for (int i = 0; i < n; i++)
            {
                jaggedArrOne[i] = Console.ReadLine().Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries).ToArray();
                numOfCells += jaggedArrOne[i].Length;
            }
            
            for (int i = 0; i < n; i++)
            {
                jaggedArrTwo[i] = Console.ReadLine().Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray();
                numOfCells += jaggedArrTwo[i].Length;
                
            }
            if (IsFit(jaggedArrOne, jaggedArrTwo))
            {

                for (int row = 0; row < jaggedArrOne.Length; row++)
                {
                    Console.Write("[");
                    Console.Write(string.Join(", ",jaggedArrOne[row]));
                    Console.Write(", ");
                    Console.Write(string.Join(", ",jaggedArrTwo[row]));
                    Console.WriteLine("]");
                }
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {numOfCells}");
            }
        }

        private static bool IsFit(string[][] jaggedArrOne, string[][] jaggedArrTwo)
        {
            if (jaggedArrOne.Length == jaggedArrTwo.Length)
            {
                int rowLength = jaggedArrOne[0].Length + jaggedArrTwo[0].Length;
                for (int row = 0; row < jaggedArrOne.Length; row++)
                {
                    if (rowLength != jaggedArrOne[row].Length + jaggedArrTwo[row].Length)
                    {
                        return false;
                    }
                }
                return true;
            }

            return false;
        }

        private static void PrintArr(int[][] jaggedArr)
        {
            for (int row = 0; row < jaggedArr.Length; row++)
            {
                for (int col = 0; col < jaggedArr[row].Length; col++)
                {
                    Console.Write(jaggedArr[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
