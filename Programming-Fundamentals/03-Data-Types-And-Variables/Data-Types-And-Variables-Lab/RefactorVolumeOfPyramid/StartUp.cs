using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorVolumeOfPyramid
{
    class StartUp
    {
        static void Main(string[] args)
        {

            double length = 0.0;

            Console.Write("Length: ");
            length = double.Parse(Console.ReadLine());

            double width = 0.0;
            Console.Write("Width: ");
            width = double.Parse(Console.ReadLine());

            double height = 0.0;
            Console.Write("Height: ");
            height = double.Parse(Console.ReadLine());
            double basePyramid = length * width;

            height = (basePyramid *height) / 3;

            Console.WriteLine("Pyramid Volume: {0:F2}", height);



        }
    }
}
