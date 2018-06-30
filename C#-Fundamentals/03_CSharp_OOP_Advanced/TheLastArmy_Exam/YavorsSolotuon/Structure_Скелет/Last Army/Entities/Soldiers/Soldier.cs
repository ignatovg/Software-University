using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    private const double MaxEndurance = 100;
    protected const int BaseRegenerateConst = 10;
    private  double endurance;
    //private double endurance;

    //public IDictionary<string, IAmmunition> Weapons { get; }

    //protected abstract IReadOnlyList<string> WeaponsAllowed { get; }



    //private void AmmunitionRevision(double missionWearLevelDecrement)
    //{
    //    IEnumerable<string> keys = this.Weapons.Keys.ToList();
    //    foreach (string weaponName in keys)
    //    {
    //        this.Weapons[weaponName].DecreaseWearLevel(missionWearLevelDecrement);

    //        if (this.Weapons[weaponName].WearLevel <= 0)
    //        {
    //            this.Weapons[weaponName] = null;
    //        }
    //    }
    //}

    

    public string Name { get; }

    public int Age { get; }

    public double Experience { get; private set; }

    public double Endurance
    {
        get => endurance;
        set => endurance = Math.Min(MaxEndurance,value);
    }

    protected abstract double OverallSkillMultiplier { get; }

    public double OverallSkill => (Age + Experience) * OverallSkillMultiplier;

    protected abstract List<string> WeaponsAllowed { get; }

    public IDictionary<string, IAmmunition> Weapons { get; }

    protected  virtual int RenerateIncrease => BaseRegenerateConst;

    protected Soldier(string name, int age, double experience, double endurance)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.endurance = endurance;
        Weapons = new Dictionary<string, IAmmunition>();

        foreach (string weapon in WeaponsAllowed)
        {
            Weapons.Add(weapon, null);
        }
    }

    public void Regenerate()
    {
        this.Endurance += this.RenerateIncrease + this.Age;
    }

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        bool hasAllEquipment = this.Weapons.Values.All(weapon => weapon != null);

        if (!hasAllEquipment)
        {
            return false;
        }

        return this.Weapons.Values.All(weapon => weapon.WearLevel > 0);
    }

    public void CompleteMission(IMission mission)
    {
        Experience += mission.EnduranceRequired;
        Endurance -= mission.EnduranceRequired;


        foreach (var weapon in Weapons.Values.Where(w=>w!=null).ToList())
        {
            weapon.DecreaseWearLevel(mission.WearLevelDecrement);
            if (weapon.WearLevel <= 0)
                Weapons[weapon.Name] = null;
            
        }
    }

    public override string ToString() => string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);

}