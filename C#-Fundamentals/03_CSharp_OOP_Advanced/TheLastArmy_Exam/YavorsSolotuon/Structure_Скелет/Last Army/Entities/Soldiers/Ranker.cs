
using System.Collections.Generic;

public class Ranker : Soldier
{
    private const double OverallSkillMiltiplierConst = 1.5;

    private readonly List<string> weaponsAllowed = new List<string>
        {
            "Gun",
            "AutomaticMachine",
            "Helmet",
        };

    public Ranker(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
    }

    protected override List<string> WeaponsAllowed => weaponsAllowed;

    protected override double OverallSkillMultiplier => OverallSkillMiltiplierConst;
    
}

