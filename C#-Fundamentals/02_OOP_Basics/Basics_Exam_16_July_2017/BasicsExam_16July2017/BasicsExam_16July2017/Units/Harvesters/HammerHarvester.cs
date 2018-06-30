public class HammerHarvester : Harvester
{
    public override string Type => "Hammer";

    public HammerHarvester(string id, double oreOurput, double energyRequirement) : base(id, oreOurput * 3, energyRequirement * 2)
    {
    }

   
}
