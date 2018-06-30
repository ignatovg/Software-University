using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerToHexAndBinary
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int intValue=int.Parse(Console.ReadLine());

            string hexValue = intValue.ToString("X");
            Console.WriteLine(hexValue);

            string binaryValue = Convert.ToString(intValue, 2);
            Console.WriteLine(binaryValue);
        }
    }
}
