public abstract class Ammunition:IAmmunition
{
    public string Name { get; }
    public double Weight { get; }
    public double WearLevel { get; }

    protected Ammunition(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
    }


    //TODO: add logic
    public void DecreaseWearLevel(double wearAmount)
    {
        throw new System.NotImplementedException();
    }
}

