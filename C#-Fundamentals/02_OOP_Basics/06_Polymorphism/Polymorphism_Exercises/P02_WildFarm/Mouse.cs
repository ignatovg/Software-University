using System;
using System.Collections.Generic;

public class Mouse:Mammal,IMammal
{
    public Mouse(string name, double weight, string foodEaten, string livingRegion, int foodQuantity) : base(name, weight, foodEaten, livingRegion, foodQuantity)
    {
    }

    private readonly List<string> kindOfFood = new List<string> { "Vegetable", "Fruit", };
    
    public override void Eat()
    {
        if (!kindOfFood.Contains(this.FoodEaten))
        {
            this.FoodQuantity = 0;
            throw new ArgumentException($"{GetType().Name} does not eat {this.FoodEaten}!");
        }
        this.Weight += this.FoodQuantity * MOUSE;
    }

    public override string ToString()
    {
        return $"Squeak";
    }

    
}

