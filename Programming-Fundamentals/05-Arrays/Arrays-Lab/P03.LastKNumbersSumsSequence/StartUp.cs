using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.LastKNumbersSumsSequence
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n= int.Parse(Console.ReadLine());
            int k= int.Parse(Console.ReadLine());
            long[] seq=new long[n];
            seq[0] = 1;
            for (int i = 1; i < n; i++)
            {
                long sum = 0;
                for (int prev = i-k; prev <= i-1; prev++)
                {
                    if (prev >= 0)
                    {
                        sum += seq[prev];
                    }
                    seq[i] = sum;
                }
            }
            Console.WriteLine(string.Join(" ",seq));
        }
    }
}
