using System;
using System.Collections.Generic;

public class Cat : Feline, IFeline
{

    public Cat(string name, double weight, string foodEaten, string livingRegion, int foodQuantity, string bread) : base(name, weight, foodEaten, livingRegion, foodQuantity, bread)
    {
    }
    private readonly List<string> kindOfFood = new List<string> { "Vegetable", "Meat", };
    
    public override void Eat()
    {
        if (!kindOfFood.Contains(this.FoodEaten))
        {
            this.FoodQuantity = 0;
            throw new ArgumentException($"{GetType().Name} does not eat {this.FoodEaten}!");
        }
        this.Weight += this.FoodQuantity * CAT;
    }

    public override string ToString()
    {
        return $"Meow";
    }
}

