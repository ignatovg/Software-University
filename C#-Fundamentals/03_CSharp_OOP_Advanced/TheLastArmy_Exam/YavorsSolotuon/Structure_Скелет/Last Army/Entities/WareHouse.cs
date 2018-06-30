using System.Collections.Generic;
using System.Linq;

public class WareHouse:IWareHouse
{
    private Dictionary<string, int> ammunitionsQuantities;
    private IAmmunitionFactory ammunitionFactory;
    public WareHouse()
    {
        this.ammunitionsQuantities = new Dictionary<string, int>();
        this.ammunitionFactory = new AmmunitionFactory();
       
    }

    public void AddAmmunition(string ammunition, int quantity)
    {
        if (ammunitionsQuantities.ContainsKey(ammunition))
        {
            ammunitionsQuantities[ammunition] += quantity;
        }
        else
        {
            ammunitionsQuantities.Add(ammunition, quantity);
        }
    }

    public void EquipArmy(IArmy army)
    {
        foreach (ISoldier soldier in army.Soldiers)
        {
            TryEquipSoldier(soldier);
        }
    }

    public bool TryEquipSoldier(ISoldier soldier)
    {
        var wornOutWeapons = soldier.Weapons.Where(w => w.Value == null).Select(w=>w.Key).ToList();

        var isSoldierEquiped = true;
        foreach (string weapon in wornOutWeapons)
        {
            if (ammunitionsQuantities.ContainsKey(weapon) && ammunitionsQuantities[weapon] > 0)
            {
                soldier.Weapons[weapon] = ammunitionFactory.CreateAmmunition(weapon);
                ammunitionsQuantities[weapon]--;
            }
            else
            {
                isSoldierEquiped = false;
            }
        }

        return isSoldierEquiped;
    }
}

