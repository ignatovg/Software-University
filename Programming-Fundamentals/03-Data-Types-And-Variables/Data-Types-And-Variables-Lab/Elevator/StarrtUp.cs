﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator
{
    class StarrtUp
    {
        static void Main(string[] args)
        {
            int persons =int.Parse(Console.ReadLine());
            int capacity =int.Parse(Console.ReadLine());
            int courses = (int)Math.Ceiling((double)persons / capacity);
            Console.WriteLine(courses);
        }
    }
}
