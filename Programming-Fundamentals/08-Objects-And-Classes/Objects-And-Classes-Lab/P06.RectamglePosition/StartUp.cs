using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06.RectamglePosition
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Rectangle rect1 = ReadRectangle();
            Rectangle rect2 = ReadRectangle();

            bool isInside = rect1.Inside(rect2);

            if (isInside)
            {
                Console.WriteLine("Inside");
            }
            else
            {
                Console.WriteLine("Not inside");
            }

        }

        public static Rectangle ReadRectangle()
        {
            int[] rectInfo = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Rectangle rect = new Rectangle
            {
                Left = rectInfo[0],
                Top = rectInfo[1],
                Width = rectInfo[2],
                Height = rectInfo[3],
            };

            return rect;
        }
    }

    class Rectangle
    {
        public int Left { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public int Bottom
        {
            get { return Top + Height; }
        }

        public int Right
        {
            get { return Left + Width; }
        }

        public bool Inside(Rectangle r)
        {
            return (r.Left <= Left) && (r.Right >= Right) && (r.Top <= Top) && (r.Bottom >= Bottom);
        }
    }
}
