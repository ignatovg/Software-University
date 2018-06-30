using System.Collections.Generic;

public class Person
{
    private string name;
    private decimal money;
    private List<Product> Products { get; set; }

    public Person()
    {
        Products = new List<Product>();
    }

    public Person(string name, decimal money):this()
    {
        this.Name = name;
        this.Money = money;
    }

    public decimal Money
    {
        get { return money; }
        set
        {
            Validator.ValidateMoney(value);
            money = value;
        }
    }

    public string Name
    {
        get { return name; }
        set
        {
            Validator.ValidateName(value);
            name = value;
        }
    }

    public string TryBuyProduct(Product product)
    {
        if(this.Money < product.Price)
        {
            return $"{name} can't afford {product.Name}";
        }
        this.Money -= product.Price;
        this.Products.Add(product);

        return $"{name} bought {product.Name}";
    }

    public override string ToString()
    {
        string products = this.Products.Count > 0 ? 
            string.Join(", ", Products) : "Nothing bought";
        return $"{Name} - {products}";
    }
}
