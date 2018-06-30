using System;
using System.Collections.Generic;
using System.Text;

namespace P10_ExplicitInterfaces
{
    interface IPerson
    {
        string Name { get; set; }
        int Age { get; set; }
        void GetName();
    }
}
