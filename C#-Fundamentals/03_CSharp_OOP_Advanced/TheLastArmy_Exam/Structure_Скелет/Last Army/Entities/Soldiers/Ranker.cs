using System.Collections.Generic;

public class Ranker : Soldier
{
    private const double OverallSkillMiltiplier = 1.5;
    private readonly List<string> weaponsAllowed = new List<string>
    {
        "Gun",
        "AutomaticMachine",
        "Helmet",
    };
    protected override IReadOnlyList<string> WeaponsAllowed => weaponsAllowed;

    public Ranker(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
        this.OverallSkill = (this.Age + this.Experience)* OverallSkillMiltiplier;
    }

}

