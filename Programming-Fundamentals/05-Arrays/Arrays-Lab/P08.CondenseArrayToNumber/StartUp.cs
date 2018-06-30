using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P08.CondenseArrayToNumber
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            

            while (nums.Length>1)
            {
                int[] condensed = new int[nums.Length - 1];

                for (int i = 0; i < nums.Length; i++)
                {
                    if (i + 1 != nums.Length)
                    {
                        condensed[i] = nums[i] + nums[i + 1];
                    }
                }
                nums = condensed;
            }
            Console.WriteLine(string.Join(" ",nums));
        }
    }
}
