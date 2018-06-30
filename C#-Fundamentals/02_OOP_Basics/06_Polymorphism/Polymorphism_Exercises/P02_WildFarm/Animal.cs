public abstract class Animal:IAnimal,IFood
{

    protected const double HEN = 0.35;
    protected const double OWL = 0.25;
    protected const double MOUSE = 0.10;
    protected const double CAT = 0.30;
    protected const double DOG = 0.40;
    protected const double TIGER = 1.00;

    protected Animal(string name, double weight, string foodEaten, int foodQuantity)
    {
        this.Name = name;
        this.Weight = weight;
        this.FoodEaten = foodEaten;
        this.FoodQuantity = foodQuantity;
    }

    public string Name { get; }
    public double Weight { get; protected set; }
    public string FoodEaten { get; }
    public int FoodQuantity { get; protected set; }

    public abstract void Eat();

}

