using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.SumMinMaxAverage
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n =int.Parse(Console.ReadLine());
            var nums = new int[n];

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i]=int.Parse(Console.ReadLine());
            }
            Console.WriteLine($"Sum = {nums.Sum()}");
            Console.WriteLine($"Min = {nums.Min()}");
            Console.WriteLine($"Max = {nums.Max()}");
            Console.WriteLine($"Average = {nums.Average()}");
        }
    }
}
