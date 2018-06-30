public class SolarProvider : Provider
{
    private const int IncreaseDurability = 500;

    public SolarProvider(int id, double energyOutput) : base(id, energyOutput)
    {
        this.Durability += IncreaseDurability;
    }
}
