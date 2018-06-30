using System;
using System.Collections.Generic;
using System.Text;

namespace P10_ExplicitInterfaces
{
    interface IResident
    {
         string Name { get; set; }
        string Country { get; set; }
        void GetName();
    }
}
