using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.ReverseAnArrayOfIntegers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n=int.Parse(Console.ReadLine());
            int[] arr=new int[n];

            for (int i = n - 1; i >= 0; i--)
            {
                arr[i]=int.Parse(Console.ReadLine());
            }
            Console.WriteLine(string.Join(" ",arr));
        }
    }
}
