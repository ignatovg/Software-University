using System;
using System.Collections.Generic;
using System.Text;

namespace P05_BorderControl
{
    interface ICitizen
    {
        string Name { get; set; }
        int Age { get; set; }
        string Id { get; set; }
        string Birthdate { get; set; }
    }
}
