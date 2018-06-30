using System;
using System.Collections.Generic;
using System.Text;

namespace P05_BorderControl
{
    interface IRobot
    {
        string Id { get; set; }
        string Model { get; set; }
        string Birthdate { get; set; }
    }
}
