using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.MaxSequenceOfEqualElements
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("input.txt").Split(' ').Select(int.Parse).ToArray();

            int bestMatch = 0;
            int bestOccurrence = 0;

            int match = 0;
            int occurrence = 1;

            for (int i = 0; i < input.Length-1; i++)
            {
                if (input[i] == input[i + 1])
                {
                    match = input[i];
                    occurrence++;
                }
                else
                {
                    match = input[i + 1];
                    occurrence = 1;
                }

                if (bestOccurrence < occurrence)
                {
                    bestOccurrence = occurrence;
                    bestMatch = match;
                }
            }
          
            for (int i = 0; i < bestOccurrence; i++)
            {
                File.AppendAllText("output.txt",$"{bestMatch} ");
            }

        }
    }
}
