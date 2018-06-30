public abstract class Provider
{
    private const int InitialDurability = 1000;

    protected Provider(int id, double energyOutput)
    {
        this.ID = id;
        this.EnergyOutput = energyOutput;
        this.Durability = InitialDurability;
    }

    public int ID { get;protected set; }
    public double EnergyOutput { get; protected set; }
    public double Durability { get; protected set; }
}