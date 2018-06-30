using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04._1.DistanceBetweenPoints
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Point p1 = ReadPoint();
            Point p2 = ReadPoint();

            double distance = CalcDistance(p1, p2);
            Console.WriteLine($"{distance:f3}");
        }

       public  static Point ReadPoint()
         {
             int[] pointInfo = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

             Point point = new Point
             {
                 X = pointInfo[0],
                 Y = pointInfo[1]
             };

             return point;
         }

        public static double CalcDistance(Point p1, Point p2)
        {
            int sideA = Math.Abs(p1.X - p2.X);
            int sideB = Math.Abs(p1.Y - p2.Y);
            double c = Math.Sqrt(Math.Pow(sideA, 2) + Math.Pow(sideB, 2));

            return c;
        }
    }

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
