using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01._1.OddLines
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var readLines = File.ReadAllLines("input.txt");
            var oddLines = readLines.Where((line, i) => i % 2 == 1).ToArray();

            File.WriteAllLines("output.txt",oddLines);
        }
    }
}
