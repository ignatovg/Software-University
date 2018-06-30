using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.TripleSum
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse)
                .ToArray();
            bool isContains = false;
            for (int a = 0; a < array.Length; a++)
            {
                for (int b = a + 1; b < array.Length; b++)
                {
                    if (array.Contains(array[a] + array[b]))
                    {
                        Console.WriteLine($"{array[a]} + {array[b]} == {array[a] + array[b]}");
                        isContains = true;
                    }
                }
            }
            if (!isContains)
            {
                Console.WriteLine("No");
            }
        }
    }
}
