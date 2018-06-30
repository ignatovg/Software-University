using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            while (true)
            {
                try
                {
                    n = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("dasd");
                }
            }
        }
    }
}
