using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_GenericBox
{
    class Program
    {
        static void Main(string[] args)
        {
           List<Box<int> > boxes = new List<Box<int>>();

           var nLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < nLines; i++)
            {
                var input = int.Parse(Console.ReadLine());
               
                var box = new Box<int>(input);
                boxes.Add(box);
            }

            boxes = SwapElements(boxes);
            boxes.ToList().ForEach(Console.WriteLine);
        }

        private static List<Box<T>> SwapElements<T>(List<Box<T>> boxes)
        {
            var indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var temp = boxes[indexes[0]];
            boxes[indexes[0]] = boxes[indexes[1]];
            boxes[indexes[1]] = temp;

            return boxes;
        }
    }
}
