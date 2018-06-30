using System;
using System.Linq;

namespace CountUpperCaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine()
                .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            Func<string, bool> checker = s => s[0] == s.ToUpper()[0];

            words.Where(checker)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
