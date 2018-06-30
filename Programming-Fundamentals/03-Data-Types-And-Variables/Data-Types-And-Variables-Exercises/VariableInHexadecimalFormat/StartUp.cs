using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariableInHexadecimalFormat
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int convertToInt = Convert.ToInt32(input, 16);
            Console.WriteLine(convertToInt);
        }
    }
}
