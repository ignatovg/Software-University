using System;

class Topping
{
    private const double MEAT = 1.2;
    private const double VEGGIES = 0.8;
    private const double CHEESE = 1.1;
    private const double SAUCE = 0.9;

    private double toppingType;

    public double ToppingTypeType
    {
        get { return toppingType; }
    }
    private double weight;

    public double Weight
    {
        get { return weight; }
    }

    public Topping()
    {
        
    }

    public Topping(string topping, double weight)
    {
        string currentTopping = topping.ToLower();
        if (currentTopping == "meat")
        {
            this.toppingType = MEAT;
        }else if (currentTopping == "veggies")
        {
            this.toppingType = VEGGIES;
        }
        else if (currentTopping == "cheese")
        {
            this.toppingType = CHEESE;
        }
        else if (currentTopping == "sauce")
        {
            this.toppingType = SAUCE;
        }
        else
        {
            throw new ArgumentException($"Cannot place {topping} on top of your pizza.");
        }
        if (weight < 1 || weight > 50)
        {
            throw new ArgumentException($"{topping} weight should be in the range [1..50].");
        }
        this.weight = weight;
    }

    public double CalcualteCalories()
    {
        return (2 * weight) * toppingType;
    }
}
