using System;
using System.Collections.Generic;

class Pizza
{
    private string name;

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) 
                || value.Length>15 || value.Length < 1)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            name = value;
        }
    }

    public List<Topping> Toppings { get; }
    public Dough Dough { get; set; }
    public int NumberOfToppings { get; private set; }
    public double TotalCalories { get; private set; }
    public Pizza(string name)
    {
        this.Name = name;

        Toppings = new List<Topping>();
        Dough = new Dough();
    }

    public void AddTopping(Topping topping)
    {
        //possible bug
        if (NumberOfToppings > 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");

        }
        this.Toppings.Add(topping);
        IncreaseToppingNumber();
    }
    public void AddCalories(double calories)
    {
        this.TotalCalories += calories;
    }

    private void IncreaseToppingNumber()
    {
        this.NumberOfToppings++;
    }

    public override string ToString()
    {
        return $"{Name} - {TotalCalories:f2} Calories.";
    }
}
