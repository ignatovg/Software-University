
public abstract class Animal
{
    protected Animal(string name, string favouriteFood)
    {
        this.Name = name;
        this.FavouriteFood = favouriteFood;
    }

    private string Name { get; set; }

    private string FavouriteFood { get; set; }

    public virtual string ExplainSelf()
    {
        string result = $"I am {this.Name} and my fovourite food is {this.FavouriteFood}";
        return result;
    }
}

