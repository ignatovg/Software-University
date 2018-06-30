using System;
using System.Collections.Generic;
using System.Text;
using Dungeons_Exam.Bags;
using Dungeons_Exam.Items;

namespace Dungeons_Exam.Characters
{
    public abstract class Character
    {
        protected Character()
        {

        }
        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, string faction)
        {
            this.Name = name;
            this.Health = health;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.TryParceFaction(faction);
            this.IsAlive = true;
            this.RestHealMultiplier = 0.2;
            this.IsRested = false;
            this.HealBefore = 0;

        }

        private string name;
        private double health;
        private double armor;


        public enum Faction
        {
            CSharp, Java
        }

        public double HealBefore { get; private set; }
        
        public bool IsRested { get; private set; }

        public Faction CurrentFaction { get; set; }

        public void TryParceFaction(string faction)
        {
            bool validFaction = Enum.TryParse(typeof(Character.Faction), faction, out object factionObj);

            if (!validFaction)
            {
                //todo check messege
                throw new ArgumentException("Invalid faction!");
            }
            Faction factionn = (Faction)factionObj;
           this.CurrentFaction = factionn;
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                name = value;
            }
        }

        public double BaseHealth { get; protected set; }

        public double Health
        {
            get { return health; }
            private set
            {
                if (value <= 0)
                {
                    health = 0;
                }
                else if (value > this.BaseHealth)
                {
                    health = this.BaseHealth;
                }
                else
                {
                    health = value;
                }
            }
        }

        public double BaseArmor { get; protected set; }

        public double Armor
        {
            get { return armor; }
            private set
            {
                if (value <= 0)
                {
                    armor = 0;
                }
                else if (value > this.BaseArmor)
                {
                    armor = this.BaseArmor;
                }
                else
                {
                    armor = value;
                }
            }
        }

        public double AbilityPoints { get; protected set; }

        public Bag Bag { get; protected set; }

        public bool IsAlive { get; private set; }

        public virtual double RestHealMultiplier { get; }
        
        public void TakeDamage(double hitPoints)
        {
            if (this.IsAlive)
            {
                this.armor -= hitPoints;
                if (this.armor <= 0)
                {
                    double hitHealth = Math.Abs(this.armor);
                    this.Health -= hitHealth;
                    this.IsAlive = IsStillAlive();
                }
            }
        }

        public void Rest()
        {
            this.HealBefore = this.Health;

            if (this.IsAlive)
            {
                this.Health = this.Health + (this.BaseHealth * this.RestHealMultiplier);
            }
            IsRested = true;
        }

        public void UseItem(Item item)
        {
            if (IsAlive)
            {
                 item.AffectCharacter(this);
            }
        }

        public void UseItemOn(Item item, Character character)
        {
            if (IsAlive && character.IsAlive)
            {
                item.AffectCharacter(character);
            }
        }

       public void GiveCharacterItem(Item item, Character character)
        {
            if (IsAlive && character.IsAlive)
            {
              character.Bag.bags.Add(item);
            }
        }

        public void ReceiveItem(Item item)
        {
            if (IsAlive)
            {
                Bag.bags.Add(item);
            }
        }

        private bool IsStillAlive()
        {
            if (this.Health > 0)
            {
                return true;
            }
            return false;
        }

        public bool IsCharakterAlive()
        {
            return this.IsAlive;
        }

        public void IncreaseHealth(int healthPotion)
        {
            this.Health += healthPotion;
        }

        public void DecreaseHealth(int decreaseHealthBy)
        {
            this.Health -= decreaseHealthBy;
            this.IsAlive = IsStillAlive();
        }

        public void RestoreArmor()
        {
            this.Armor = this.BaseArmor;
        }

        public void Heal(double abilityPoints)
        {
            this.Health = this.Health + this.AbilityPoints;
        }
    }
}

