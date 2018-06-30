using System;
using System.Collections.Generic;

namespace P05_GenericCountMEthodString
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box<string> > boxs = new List<Box<string>>();

            int nLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < nLines; i++)
            {
                var input = (Console.ReadLine());

                var box = new Box<string>(input);
                boxs.Add(box);
            }
            var comparerEl = (Console.ReadLine());
            var compareBox = new Box<string>(comparerEl);
            Console.WriteLine(Comparer<string>.CountGreater(compareBox,boxs));
        }
    }
}
