using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.ClosestTwoPoints
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Point[] points=new Point[n];

            for (int i = 0; i < n; i++)
            {
                Point point = ReadPoint();

                points[i] = point;
            }
            var minPoints=FindClosestPoints(points);
            Console.WriteLine($"{CalcDistance(minPoints[0],minPoints[1]):f3}");
            Console.WriteLine($"({minPoints[0].X}, {minPoints[0].Y})");
            Console.WriteLine($"({minPoints[1].X}, {minPoints[1].Y})");
        }

        public static Point[] FindClosestPoints(Point[] points)
        {
            double minDistance =Double.MaxValue;
            Point[] minPoints=new Point[2];
            for (int i = 0; i < points.Length-1; i++)
            {
                for (int k = i+1; k < points.Length; k++)
                {
                    double distance = CalcDistance(points[i], points[k]);

                    if (minDistance > distance)
                    {
                        minDistance = distance;
                        minPoints[0] = points[i];
                        minPoints[1] = points[k];
                    }
                }
               

             
            }

            return minPoints;
        }

        public static double CalcDistance(Point p1, Point p2)
        {
            int sideA = Math.Abs(p1.X - p2.X);
            int sideB = Math.Abs(p1.Y - p2.Y);
            double c = Math.Sqrt(Math.Pow(sideA, 2) + Math.Pow(sideB, 2));

            return c;
        }

        public static Point ReadPoint()
        {
            int[] infoPoint = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Point point = new Point
            {
                X = infoPoint[0],
                Y = infoPoint[1]
            };

            return point;
        }
    }

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
