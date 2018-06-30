using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace MathPower
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double number=double.Parse(Console.ReadLine());
            int power=int.Parse(Console.ReadLine());
            var poweredNumber = GetPower(number, power);
            Console.WriteLine(poweredNumber);
        }

        private static double GetPower(double number, int power)
        {
            var result = 1d;
            for (int i = 0; i < power; i++)
            {
                result = result * number;
            }
            return result;
        }
    }
}
