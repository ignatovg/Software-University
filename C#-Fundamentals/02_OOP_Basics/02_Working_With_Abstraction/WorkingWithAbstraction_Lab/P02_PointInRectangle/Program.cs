using System;
using System.Linq;

namespace P02_PointInRectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] coords = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Rectangle rectangle = new Rectangle(coords[0], coords[1],coords[2],coords[3]);

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int[] toknes = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int x = toknes[0];
                int y = toknes[1];
                Point point = new Point { X = x, Y = y };

                bool isInside = rectangle.Contains(point);
                Console.WriteLine(isInside);
            }
        }
    }
}
