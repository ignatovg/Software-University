using System.Collections.Generic;
using System.Text;


public class SpecialForce : Soldier
{
    private const int BaseRegenerateConst = 30;
    private const double OverallSkillMiltiplierConst = 3.5;

    private readonly List<string> weaponsAllowed = new List<string>
        {
            "Gun",
            "AutomaticMachine",
            "MachineGun",
            "RPG",
            "Helmet",
            "Knife",
            "NightVision"
        };

    public SpecialForce(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
    }

    protected override List<string> WeaponsAllowed => weaponsAllowed;

    protected override double OverallSkillMultiplier => OverallSkillMiltiplierConst;

    public override void Regenerate()
    {
        this.Endurance += BaseRegenerateConst + this.Age;
    }
}
