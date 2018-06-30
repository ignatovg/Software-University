using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.AppendList
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] tokkens = Console.ReadLine().Split('|');
            List<int> result=new List<int>();

            for (int i = tokkens.Length - 1; i >= 0; i--)
            {
                result.AddRange(tokkens[i]
                    .Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList());
            }
            Console.WriteLine(string.Join(" ",result));
        }
    }
}
