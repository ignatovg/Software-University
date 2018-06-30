using System;
using System.IO;

namespace P02_LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var stream = new StreamReader("../text.txt"))
            {
                int numberOfLine = 1;
                string line = stream.ReadLine();
                while (line!=null)
                {
                    Console.WriteLine($"{numberOfLine++}: {line}");
                    line = stream.ReadLine();
                }
            }
        }
    }
}
