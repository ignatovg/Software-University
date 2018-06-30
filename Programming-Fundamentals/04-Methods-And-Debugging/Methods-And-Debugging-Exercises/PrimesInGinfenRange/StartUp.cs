using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimesInGinfenRange
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int startNum =int.Parse(Console.ReadLine());
            int endNum =int.Parse(Console.ReadLine());

            if (startNum > endNum)
            {
                Console.WriteLine("(empty list)");
                return;
            }
            Console.WriteLine(string.Join(", ",FindPrimesInRange(startNum,endNum)));
        }

        static List<int> FindPrimesInRange(int startNum, int endNum)
        {
            List<int> primesList=new List<int>();

            for (int i = startNum; i <= endNum; i++)
            {
                if (IsPrime(i))
                {
                    primesList.Add(i);        
                }
            }
            return primesList;
        }

        static bool IsPrime(long number)
        {
            if (number == 1 || number == 0)
            {
                return false;
            }
            if (number == 2)
            {
                return true;
            }

            for (int i = 2; i <= Math.Ceiling(Math.Sqrt(number)); ++i)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
