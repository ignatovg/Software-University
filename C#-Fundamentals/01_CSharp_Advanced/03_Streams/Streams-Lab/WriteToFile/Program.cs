using System;
using System.IO;

namespace WriteToFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var readStream = new StreamReader("Program.cs"))
            {
                using (var writeStream = new StreamWriter("reversed.txt"))
                {

                    string line = readStream.ReadLine();
                    while (line != null)
                    {
                        for (int counter = line.Length - 1; counter >= 0; counter--)
                        {
                            writeStream.Write(line[counter]);
                        }
                        writeStream.WriteLine();
                        line = readStream.ReadLine();
                    }
                }
            }
        }
    }
}
