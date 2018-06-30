using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveDemo
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //irectory.CreateDirectory(@"..\..\results");
            // File.WriteAllText(@"..\..\results\results.txt","ohaa its working");
            var files = Directory.GetDirectories(@"..\..\");
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
        }
    }
}
