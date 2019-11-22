using System.Collections.Generic;

public class Corporal : Soldier
{
    private const double OverallSkillMiltiplierConst = 2.5;

    private readonly List<string> weaponsAllowed = new List<string>
    {
        "Gun",
        "AutomaticMachine",
        "MachineGun",
        "Helmet",
        "Knife"
    };

    public Corporal(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
    }

    protected override List<string> WeaponsAllowed => weaponsAllowed;

    protected override double OverallSkillMultiplier => OverallSkillMiltiplierConst;

}

