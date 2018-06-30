using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BooleanVariable
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            bool convertToBool = Convert.ToBoolean(input);

            Console.WriteLine(convertToBool ? "Yes" : "No");
        }
    }
}
