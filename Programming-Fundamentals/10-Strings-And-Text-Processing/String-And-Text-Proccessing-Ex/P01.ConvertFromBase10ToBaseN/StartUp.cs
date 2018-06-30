using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace P01.ConvertFromBase10ToBaseN
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine().Split(' ');

            int n = int.Parse(line[0]);
            BigInteger number = BigInteger.Parse(line[1]);
            List<BigInteger> result = new List<BigInteger>();
            while (number>0)
            {
                BigInteger rem = number % n;
               result.Add(rem);
                number = number / n;
            }
            string binStr = "";
            for (int i = result.Count-1; i >= 0; i--)
            {
                binStr= binStr+result[i].ToString();
            }
            Console.WriteLine(binStr);

           
        }
    }
}
