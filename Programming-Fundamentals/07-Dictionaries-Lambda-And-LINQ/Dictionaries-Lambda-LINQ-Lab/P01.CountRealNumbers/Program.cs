using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            var dict=new SortedDictionary<double,int>();

            for (int i = 0; i < arr.Length; i++)
            {
                double num = arr[i];
                if (!dict.ContainsKey(num))
                {
                    dict.Add(num,0);
                }
                dict[num]++;
            }
            Console.WriteLine(string.Join("\r\n",
                dict.Select(x=> x.Key + " -> " + x.Value)));
        }
    }
}
