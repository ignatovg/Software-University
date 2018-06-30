using System;
using System.Collections.Generic;

public class SpecialForce : Soldier
{
    private const int RegenerationIncreaser = 30;

    private const double OverallSkillMiltiplier = 3.5;
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
    protected override IReadOnlyList<string> WeaponsAllowed => weaponsAllowed;

    public SpecialForce(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
        this.OverallSkill = (this.Age + this.Experience) * OverallSkillMiltiplier;
    }

    public override void Regenerate()
    {
        this.Endurance += this.Age + RegenerationIncreaser;
        this.Endurance = Math.Min(this.Endurance, 100);
    }
}
