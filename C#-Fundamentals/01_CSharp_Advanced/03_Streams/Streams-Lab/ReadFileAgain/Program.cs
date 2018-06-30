using System;
using System.IO;

namespace ReadFileAgain
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader stream = new StreamReader("Program.cs");
            using (stream)
            {
                int numberLine = 1;
                string line = stream.ReadLine();

                while (line!=null)
                {
                    Console.WriteLine($"{numberLine}: {line}");
                    numberLine++;

                    line = stream.ReadLine();
                }
            }
        }
    }
}
