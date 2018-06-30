using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateTriangleArea
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double width= double.Parse(Console.ReadLine());
            double height =double.Parse(Console.ReadLine());
            var area = GetTriangleArea(width, height);
            Console.WriteLine(area);
        }

        private static double GetTriangleArea(double width, double height)
        {
            return width * height / 2;
        }
    }
}
