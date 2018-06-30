using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Dungeons_Exam.Bags;
using Dungeons_Exam.Interfaces;

namespace Dungeons_Exam.Characters
{
    public class Cleric : Character,IHealable
    {
        public Cleric(string name, Faction faction)
        {
            this.Name = name;
            this.CurrentFaction = faction;
            this.BaseHealth = 50;
            this.BaseArmor = 25;
            this.AbilityPoints = 40;
            this.Bag = new Backpack();
        }

        public override double RestHealMultiplier => 0.5;

        public void Heal(Character character)
        {
            if (IsAlive && character.IsAlive)
            {
                //todo faction

                character.Heal(this.AbilityPoints);
                
            }    
        }
    
        
    }
}
