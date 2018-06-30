using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingDictionary
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var arr = new int[] {10, 10, 20, 20, 10, 20,15};

            var dict = arr.Distinct().ToDictionary(x=> x, x=>0);

            foreach (var num in arr)
            {
                dict[num]++;
            }

            Console.WriteLine(string.Join("\r\n",dict.Select(x=>x.Key+ "-> " +x.Value)));
        }
    }
}
