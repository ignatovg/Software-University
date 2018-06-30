using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircleArea_Precision12_
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double radius=double.Parse(Console.ReadLine());

            Console.WriteLine($"{radius*radius*Math.PI:f12}");
        }
    }
}
