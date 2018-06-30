using System;
using System.Collections.Generic;

public class Hen : Bird,IBird
{
    public Hen(string name, double weight, string foodEaten, int foodQuantity, double wingSize) : base(name, weight, foodEaten, foodQuantity,wingSize)
    {
    }

    private readonly List<string> kindOfFood = new List<string>{ "Vegetable", "Fruit", "Meat", "Seeds", };
    
    public override void Eat()
    {
        if (!kindOfFood.Contains(this.FoodEaten))
        {
            this.FoodQuantity = 0;
            throw new ArgumentException($"{GetType().Name} does not eat {this.FoodEaten}!");
        }
        this.Weight += this.FoodQuantity * HEN;
    }

    public override string ToString()
    {
        return $"Cluck";
    }
}

