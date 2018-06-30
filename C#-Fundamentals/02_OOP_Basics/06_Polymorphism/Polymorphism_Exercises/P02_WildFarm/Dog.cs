using System;
using System.Collections.Generic;

public class Dog : Mammal, IMammal
{
    public Dog(string name, double weight, string foodEaten, string livingRegion, int foodQuantity) : base(name, weight, foodEaten, livingRegion, foodQuantity)
    {
    }

    private readonly List<string> kindOfFood = new List<string> { "Meat" };

    
    public override void Eat()
    {
        if (!kindOfFood.Contains(this.FoodEaten))
        {
            this.FoodQuantity = 0;
            throw new ArgumentException($"{GetType().Name} does not eat {this.FoodEaten}!");
        }
        this.Weight += this.FoodQuantity * DOG;
    }

    public override string ToString()
    {
        return $"Woof!";
    }
}

