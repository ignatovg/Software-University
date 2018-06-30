using System;
using System.Collections.Generic;
using System.Text;

namespace P07_FoodStorage
{
    interface IBuyer
    {
        string Type { get; }
        string Name { get; set; }
        int Age { get; set; }
        int Food { get; set; }
        void BuyFood();
    }
}
