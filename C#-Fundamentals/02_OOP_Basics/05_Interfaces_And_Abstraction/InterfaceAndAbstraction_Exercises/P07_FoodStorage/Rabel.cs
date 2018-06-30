using System;
using System.Collections.Generic;
using System.Text;

namespace P07_FoodStorage
{
    class Rabel:IInfo,IBuyer
    {
        public string Type { get; } = "Rabel";
        public string Name { get; set; }
        public int Age { get; set; }
        public string Group { get; set; }

        public int Food { get; set; } 

        public Rabel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }
        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
