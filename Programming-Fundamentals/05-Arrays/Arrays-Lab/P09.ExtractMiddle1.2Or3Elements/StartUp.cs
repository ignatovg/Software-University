using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P09.ExtractMiddle1._2Or3Elements
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            if (arr.Length == 1)
            {
                Console.WriteLine($"{{ {5} }}");
            }
            else if (arr.Length % 2 == 0)
            {
                int first = arr.Length / 2 - 1;
                int second = arr.Length / 2;
                Console.WriteLine($"{{ {arr[first]}, {arr[second]} }}");
            }
            else
            {
                int first = arr.Length / 2 - 1;
                int second = arr.Length / 2;
                int third = arr.Length / 2 + 1;
                Console.WriteLine($"{{ {arr[first]}, {arr[second]}, " +
                                  $"{arr[third]} }}");
            }
        }
    }
}
