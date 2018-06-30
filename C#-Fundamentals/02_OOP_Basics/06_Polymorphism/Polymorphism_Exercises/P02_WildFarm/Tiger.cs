using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class Tiger : Feline, IFeline
{
    public Tiger(string name, double weight, string foodEaten, string livingRegion, int foodQuantity, string bread) : base(name, weight, foodEaten, livingRegion, foodQuantity, bread)
    {
    }

    private readonly List<string> kindOfFood = new List<string> {"Meat" };
    
    public override void Eat()
    {
        if (!kindOfFood.Contains(this.FoodEaten))
        {
            this.FoodQuantity = 0;
            throw new ArgumentException($"{GetType().Name} does not eat {this.FoodEaten}!");
        }
        this.Weight += this.FoodQuantity * TIGER;
    }

    public override string ToString()
    {
        return $"ROAR!!!";
    }
}
