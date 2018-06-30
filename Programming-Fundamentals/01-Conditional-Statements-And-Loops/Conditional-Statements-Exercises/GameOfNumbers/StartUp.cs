using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int magicalNum = int.Parse(Console.ReadLine());
            int findI = 0;
            int findJ = 0;
            int cnt = 0;


            for (int i = N; i <= M; i++)
            {
                for (int j = N; j <= M; j++)
                {
                    if (i + j == magicalNum)
                    {
                        findI = i;
                        findJ = j;
                    }
                    cnt++;
                }
            }
            if (findI + findJ == magicalNum)
            {
                Console.WriteLine($"Number found! {findI} + {findJ} = {magicalNum}");
            }
            else
            {

                Console.WriteLine($"{cnt} combinations - neither equals {magicalNum}");
            }
        }
    }
}
