public abstract class Mammal:Animal,IAnimal,IMammal
{
    protected Mammal(string name, double weight, string foodEaten, string livingRegion, int foodQuantity) : base(name, weight, foodEaten, foodQuantity)
    {
        this.LivingRegion = livingRegion;
    }

    public string LivingRegion { get; }

   
}

