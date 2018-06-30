using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07.CountNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Dictionary<int,int> counts =new Dictionary<int, int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                int num = numbers[i];
                if (!counts.ContainsKey(num))
                {
                    counts.Add(num,0);
                }
                counts[num]++;

            }

            foreach (KeyValuePair<int, int> pair in counts.OrderBy(a=> a.Key))
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}
