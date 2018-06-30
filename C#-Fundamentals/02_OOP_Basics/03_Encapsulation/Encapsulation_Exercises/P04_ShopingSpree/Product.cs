using System;

class Product
{
    private string name;

    public string Name
    {
        get => name;
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            this.name = value;
        }
    }

    private decimal cost;

    public decimal Cost
    {
        get { return cost; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");

            }
            cost = value;
        }
    }

    public Product()
    {
        
    }

    public Product(string name, decimal cost)
    {
        this.Name = name;
        this.Cost = cost;
    }

   public  Product ParseProduct(string token)
    {
        string[] tokens = token.Split('=',StringSplitOptions.RemoveEmptyEntries);
        this.Name = tokens[0];
        this.Cost = decimal.Parse(tokens[1]);

        return this;
    }

    public override string ToString()
    {
        return $"{name}";
    }
}
