public class PressureProvider:Provider
{
    private const int DecreaseDurability = 300;
    private const int EnergyOutputMultiplier = 2;

    public PressureProvider(int id, double energyOutput) : base(id, energyOutput)
    {
        this.Durability -= DecreaseDurability;
        this.EnergyOutput *= EnergyOutputMultiplier;
    }
}

