public class SonicHarvester : Harvester
{
    private int sonicFactor;
    public override string Type => "Sonic";

    public SonicHarvester(string id, double oreOurput, double energyRequirement, int sonicFactor) : base(id, oreOurput, energyRequirement/sonicFactor)
    {
    }
}

