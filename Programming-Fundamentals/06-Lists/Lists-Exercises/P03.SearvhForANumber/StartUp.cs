using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace P03.SearvhForANumber
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int[] commands = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int[] auxiliaryArr=new int[nums[0]];
            auxiliaryArr = nums.Take(commands[0]).ToArray();
            auxiliaryArr = auxiliaryArr.Skip(commands[1]).ToArray();
            if (auxiliaryArr.Contains(commands[2]))
            {
                Console.WriteLine("YES!");
            }
            else
            {
                Console.WriteLine("NO!");
            }
        }
    }
}
