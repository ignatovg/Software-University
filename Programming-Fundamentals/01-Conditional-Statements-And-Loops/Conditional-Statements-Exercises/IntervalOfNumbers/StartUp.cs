using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntervalOfNumbers
{
    class IntervalOfNumbers
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());

            int max = Math.Max(first, second);
            int min = Math.Min(first, second);

            for (int i = min; i <= max; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
