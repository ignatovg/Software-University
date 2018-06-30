using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                if (IsPolindrome(i) && IsDevisibleBy7(i) && IsEvenDigit(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool IsEvenDigit(int number)
        {
            while (number>0)
            {
                int digit = number % 10;
                if (digit % 2 == 0)
                {
                    return true;
                }
                number /= 10;
            }
            return false;
        }
        static bool IsDevisibleBy7(int number)
        {
            int sum = 0;
            while (number>0)
            {
                sum += number % 10;
                number /= 10;
                
            }
            if (sum % 7 == 0)
            {
                return true;
            }
            return false;
        }

        static bool IsPolindrome(int number)
        {
            string numberStr=number.ToString();

            for (int i = 0; i < numberStr.Length/2; i++)
            {
                if (numberStr[i] == numberStr[numberStr.Length - 1 - i])
                {
                    continue;
                }
                else
                {
                    return false;
                } 
            }
            return true;
        }
    }
}
