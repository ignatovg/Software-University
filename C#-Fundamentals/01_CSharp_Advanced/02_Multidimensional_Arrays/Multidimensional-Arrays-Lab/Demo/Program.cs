using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix =
            {
                {1, 2 },
                {3, 4 }
            };
            Console.WriteLine(matrix[1,0]);
        }
    }
}
