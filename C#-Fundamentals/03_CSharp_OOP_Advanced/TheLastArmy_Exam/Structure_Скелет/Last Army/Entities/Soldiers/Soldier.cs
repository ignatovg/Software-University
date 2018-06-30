using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

public abstract class Soldier : ISoldier
{
    private const int RegenerationIncreaser = 10;

    protected Soldier(string name, int age, double experience, double endurance)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.Endurance = endurance;
    }

    public string Name { get; }
    public int Age { get; }
    public double Experience { get; }
    public double Endurance { get; protected set; }
    public double OverallSkill { get; protected set; }


    //todo: inject weapons
    public IDictionary<string, IAmmunition> Weapons { get; }
    
    protected abstract IReadOnlyList<string> WeaponsAllowed { get; }

    public virtual void Regenerate()
    {
        this.Endurance += this.Age + RegenerationIncreaser;
        this.Endurance = Math.Min(this.Endurance, 100);
    }

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }


        //bug
        bool hasAllEquipment = this.Weapons.Values.Count(weapon => weapon == null) == 0;

        if (!hasAllEquipment)
        {
            return false;
        }

        bool hasPossibleWeaponWearlevel = this.Weapons.Values.Count(weapon => weapon.WearLevel <= 0) == 0;

        if (!hasPossibleWeaponWearlevel)
        {
            return false;
        }

        return true;
    }

    public void CompleteMission(IMission mission)
    {
        throw new System.NotImplementedException();
    }

    private void AmmunitionRevision(double missionWearLevelDecrement)
    {
        IEnumerable<string> keys = this.Weapons.Keys.ToList();
        foreach (string weaponName in keys)
        {
            this.Weapons[weaponName].DecreaseWearLevel(missionWearLevelDecrement);

            if (this.Weapons[weaponName].WearLevel <= 0)
            {
                this.Weapons[weaponName] = null;
            }
        }
    }

    public override string ToString() => string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);
}