public abstract class Feline:Mammal,IMammal,IFeline
{
    protected Feline(string name, double weight, string foodEaten, string livingRegion, int foodQuantity, string bread) : base(name, weight, foodEaten, livingRegion, foodQuantity)
    {
        this.Bread = bread;
    }

    public string Bread { get; }

    
}
