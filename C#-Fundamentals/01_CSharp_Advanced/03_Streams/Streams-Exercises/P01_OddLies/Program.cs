using System;
using System.IO;

namespace P01_OddLies
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var stream = new StreamReader("../text.txt"))
            {
                var line = stream.ReadLine();
                int n = 0;
                while (line!=null)
                {
                    if (n % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }
                    n++;
                    line = stream.ReadLine();
                }
            }
        }
    }
}
