using System;

public abstract class Harvester:Unit
{
    private double oreOutput;
    private double energyRequirement;
    
    protected Harvester(string id, double oreOurput, double energyRequirement):base(id)
    {
        this.OreOutput = oreOurput;
        this.EnergyRequirement = energyRequirement;
    }
    
    public double OreOutput
    {
        get => oreOutput;
       private set
        {
            if (value < 0)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's {nameof(this.OreOutput)}");
            }
            this.oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get => energyRequirement;
       private set
        {
            if (value < 0 || value >= 20000)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's {nameof(this.EnergyRequirement)}");
            }
            this.energyRequirement = value;
        }
    }

    public override string ToString()
    {
        return $"{this.Type} Harvester - {this.Id}" + Environment.NewLine +
               $"Ore Output: {this.OreOutput}" + Environment.NewLine +
               $"Energy Requirement: {this.EnergyRequirement}";
    }
}
