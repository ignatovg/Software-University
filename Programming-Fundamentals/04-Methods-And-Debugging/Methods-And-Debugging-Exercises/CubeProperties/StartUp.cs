using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeProperties
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double n =double.Parse(Console.ReadLine());
            string partOfCube = Console.ReadLine();

            if (partOfCube == "face")
            {
                var result = GetFaceOfCube(n);
                Console.WriteLine($"{result:f2}");
            }
            else if (partOfCube == "space")
            {
                var result = GetSpaceOfCube(n);
                Console.WriteLine($"{result:f2}");
            }
            else if (partOfCube == "volume")
            {
                var result = GetVolumeOfCube(n);
                Console.WriteLine($"{result:f2}");
            }
            else if (partOfCube == "area")
            {
                var result = GetAreaOfCube(n);
                Console.WriteLine($"{result:f2}");
            }
        }

        private static double GetAreaOfCube(double n)
        {
            return 6 * n * n;
        }

        private static double GetVolumeOfCube(double n)
        {
            return Math.Pow(n, 3);
        }

        private static double GetSpaceOfCube(double n)
        {
            return Math.Sqrt(3 * n * n);
        }

        private static double GetFaceOfCube(double n)
        {
            return Math.Sqrt(2 * n * n);
        }
    }
}
