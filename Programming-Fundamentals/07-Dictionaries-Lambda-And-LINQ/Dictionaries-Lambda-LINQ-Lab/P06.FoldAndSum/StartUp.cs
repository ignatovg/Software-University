using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace P06.FoldAndSum
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var k = nums.Length / 4;

            var leftRow = nums.Take(k).Reverse().ToArray();
            var rightRow = nums.Reverse().Take(k).ToArray();

            var row1 = leftRow.Concat(rightRow).ToArray();
            var row2 = nums.Skip(k).Take(2 * k).ToArray();

            var sumArr = row1.Select((x, index) => x + row2[index]);

            Console.WriteLine(string.Join(" ",sumArr));
        }
        

    }
}
