using System;
using System.Text;

namespace P0_ClassBox
{
    class Program
    {


        static void Main(string[] args)
        {
            try
            {
                var lenght = double.Parse(Console.ReadLine());
                var width = double.Parse(Console.ReadLine());
                var height = double.Parse(Console.ReadLine());

                Parallelepiped parallelepiped = new Parallelepiped(lenght, width, height);

                var surfaceArea = parallelepiped.CalculateSurface();
                var lateralSurface = parallelepiped.CalcualateLateralSurface();
                var volume = parallelepiped.CalculateVolume();

                Console.WriteLine($"Surface Area - {surfaceArea:f2}");
                Console.WriteLine($"Lateral Surface Area - {lateralSurface:f2}");
                Console.WriteLine($"Volume - {volume:f2}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
