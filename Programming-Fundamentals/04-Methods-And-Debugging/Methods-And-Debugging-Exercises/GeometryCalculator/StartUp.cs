using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryCalculator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            if (figure == "triangle")
            {
                var result = GetTriangleArea();
                Console.WriteLine($"{result:f2}");
            }
            else if (figure == "square")
            {
                var result = GetSquareArea();
                Console.WriteLine($"{result:f2}");
            }
            else if (figure == "rectangle")
            {
                var result = GetRectangleArea();
                Console.WriteLine($"{result:f2}");
            }
            else if (figure == "circle")
            {
                var result = GetCircleArea();
                Console.WriteLine($"{result:f2}");
            }
        }

        private static double GetCircleArea()
        {
            double radius=double.Parse(Console.ReadLine());
            return Math.PI * radius * radius;
        }

        private static double GetRectangleArea()
        {
            double width=double.Parse(Console.ReadLine());
            double height=double.Parse(Console.ReadLine());
            return width * height;
        }

        private static double GetSquareArea()
        {
            double side = double.Parse(Console.ReadLine());
            return side * side;
        }

        private static double GetTriangleArea()
        {
            double side = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            return (side * height) / 2;
        }
    }
}
