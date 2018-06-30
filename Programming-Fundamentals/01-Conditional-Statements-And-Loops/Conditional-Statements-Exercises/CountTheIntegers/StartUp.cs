using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CountTheIntegers
{
    class CountTheIntegers
    {
        static void Main(string[] args)
        {
            int countOfNum = 0;
            try
            {
                while (true)
                {
                    int number = Int32.Parse(Console.ReadLine());
                    countOfNum++;
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(countOfNum);
            }
        }
    }
}
