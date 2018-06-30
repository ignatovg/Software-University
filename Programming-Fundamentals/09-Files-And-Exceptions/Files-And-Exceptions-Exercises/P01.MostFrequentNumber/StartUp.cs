using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.MostFrequentNumber
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var tokens = File.ReadAllText("input.txt").Split(' ').Select(int.Parse).ToArray();
            int besOccurs = 0;
            int bestDigit = 0;

            int occurs = 1;
            int digit = 0;

            for (int row1 = 0; row1 < tokens.Length-1; row1++)
            {
                for (int row2 = row1+1; row2 < tokens.Length; row2++)
                {
                    if (tokens[row1] == tokens[row2])
                    {
                        occurs++;
                        digit = tokens[row2];
                    }
                    
                }
                if (besOccurs < occurs)
                {
                    besOccurs = occurs;
                    bestDigit = digit;
                }
                occurs = 0;
            }
          File.WriteAllText("output.txt",bestDigit.ToString());
        }
    }
}
