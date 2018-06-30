using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.ShortWordsSorted
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string separators= " .,:;()[]\"'\\/!?";
            var charArray = separators.ToCharArray();

            var line = Console.ReadLine()
                .ToLower()
                .Split(charArray,StringSplitOptions.RemoveEmptyEntries)
                .Distinct()
                .ToArray();

            var shortWords = line.Where(a => a.Length < 5).OrderBy(x => x);
            Console.WriteLine(string.Join(", ",shortWords));

        }
    }
}
