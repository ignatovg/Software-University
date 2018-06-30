using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.IntersectionOfCircles
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Circle c1 = ReadCircle();
            Circle c2 = ReadCircle();

            bool isIntersect = Intersect(c1, c2);

            if (isIntersect)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }

        private static Circle ReadCircle()
        {
            int[] circleArgs = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Circle circle = new Circle
            {
                Center=new Point{X = circleArgs[0], Y = circleArgs[1]},
                Radius = circleArgs[2],
            };

            return circle;
        }

        public static bool Intersect(Circle firstCircle, Circle secondCircle)
        {
            double deltaX = Math.Abs(firstCircle.Center.X - secondCircle.Center.X);
            double deltaY = Math.Abs(firstCircle.Center.Y - secondCircle.Center.Y);
            double distance = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
            double sumRadiuses = firstCircle.Radius + secondCircle.Radius;

            if (sumRadiuses >= distance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class Circle
    {
        public Point Center { get; set; }
        public double Radius { get; set; }
    }

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
