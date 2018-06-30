using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.DistanceBetweenPoints
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] row1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] row2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Point p1 = new Point {X = row1[0], Y = row1[1]};
            Point p2 = new Point {X = row2[0], Y = row2[1]};
            
            double distance = CalcDistance(p1, p2);
            Console.WriteLine($"{distance:f3}");
        }

        public static double CalcDistance(Point p1, Point p2)
        {
            int sideA = Math.Abs(p1.X - p2.X);
            int sideB = Math.Abs(p1.Y - p2.Y);
            double c = Math.Sqrt(Math.Pow(sideA,2)+ Math.Pow(sideB,2));

            return c;
        }
    }

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

    }
}
