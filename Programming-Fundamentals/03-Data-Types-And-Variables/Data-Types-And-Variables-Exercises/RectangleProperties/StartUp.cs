using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleProperties
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double width=double.Parse(Console.ReadLine());
            double height=double.Parse(Console.ReadLine());
            
            double perimeter = 2* width + 2* height;
            Console.WriteLine(perimeter);

            double area = width * height;
            Console.WriteLine(area);

            double diagonal = Math.Sqrt(width * width + height * height);
            Console.WriteLine(diagonal);

        }
    }
}
