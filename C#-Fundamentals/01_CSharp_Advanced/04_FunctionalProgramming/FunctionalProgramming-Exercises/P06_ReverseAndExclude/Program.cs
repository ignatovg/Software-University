using System;
using System.Linq;

namespace P06_ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> namesFilter = (str, len) => str.Length <= len;
            
            int length = int.Parse(Console.ReadLine());

                 Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Where(s => namesFilter(s, length))
                .ToList().ForEach(a => Console.WriteLine(a));
        }
    }
}
