public  abstract class Bird:Animal,IBird
{
    public Bird(string name, double weight, string foodEaten, int foodQuantity, double wingSize) : base(name, weight, foodEaten, foodQuantity)
    {
        this.WingSize = wingSize;
    }

    public double WingSize { get; }

   
}

