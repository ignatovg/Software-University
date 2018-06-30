public class HammerHarvester:Harvester
{

    public HammerHarvester(string id, double oreOutput, double energyRequirement) : base(id, oreOutput, energyRequirement)
    {
        this.EnergyRequirement = energyRequirement * 2;
        this.OreOutput = oreOutput * 3;
    }

    public override string Type => "Hammer";
}

