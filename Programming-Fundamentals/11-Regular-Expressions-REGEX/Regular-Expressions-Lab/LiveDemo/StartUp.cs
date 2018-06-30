using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LiveDemo
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();

            

            foreach (Match m in Regex.Matches(text, @"(\w+)"))
            {

                Console.WriteLine(m.Groups[0]);
            }
        }
    }
}
