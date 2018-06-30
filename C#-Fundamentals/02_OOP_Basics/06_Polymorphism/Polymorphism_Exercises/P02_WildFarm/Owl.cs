using System;
using System.Collections.Generic;

public class Owl:Bird,IBird
{
    public Owl(string name, double weight, string foodEaten, int foodQuantity, double wingSize) : base(name, weight, foodEaten, foodQuantity, wingSize)
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
        this.Weight += this.FoodQuantity * OWL;
    }

    public override string ToString()
    {
        return $"Hoot Hoot";
    }

   
}

