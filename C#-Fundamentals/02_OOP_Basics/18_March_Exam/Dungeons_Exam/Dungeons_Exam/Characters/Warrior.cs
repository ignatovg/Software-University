using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Dungeons_Exam.Bags;
using Dungeons_Exam.Interfaces;

namespace Dungeons_Exam.Characters
{
    public class Warrior:Character,IAttackable
    {
        public Warrior(string name, Faction faction)
        {
            this.Name = name;
            this.CurrentFaction = faction;
            this.BaseHealth = 100;
            this.BaseArmor = 50;
            this.AbilityPoints = 40;
            this.Bag = new Satchel();
        }


        public void Attack(Character character)
        {
                if (this.IsAlive && character.IsAlive)
                {
                    if (character is Warrior)
                    {
                        throw new InvalidOperationException("Cannot attack self!");
                    }
                    //todo faction

                    character.TakeDamage(this.AbilityPoints);
                }
        }
    }
}
