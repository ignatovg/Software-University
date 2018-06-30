using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.LineNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var allLines = File.ReadAllLines("input.txt");
            for (int i = 0; i < allLines.Length; i++)
            {
                allLines[i] = $"{i+1}. {allLines[i]}";
            }

            File.WriteAllLines("output.txt",allLines);
        }
    }
}
