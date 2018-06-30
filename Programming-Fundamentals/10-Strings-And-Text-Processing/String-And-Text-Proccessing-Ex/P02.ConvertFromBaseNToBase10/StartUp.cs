using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace P02.ConvertFromBaseNToBase10
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split(' ');

            int n = int.Parse(line[0]);
            string number = line[1];

           
            char[] reversedStr= number.Reverse().ToArray();
            BigInteger result = 0;

            for (int i = 0; i < reversedStr.Length; i++)
            {
                int num = int.Parse(reversedStr[i].ToString());

                result += num *BigInteger.Pow(n, i);

            }

            Console.WriteLine(result);
           
        }
    }
}
