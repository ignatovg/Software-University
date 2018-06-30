using System;
using System.Collections.Generic;
using System.Text;
using Dungeons_Exam.Characters;


   public class CharacterFactory
    {
        public Character CreateCharacter(string[] args)
        {
            string faction = args[0];
            string characterType = args[1];
            string name = args[2];

            Character character = null;

            bool validFaction = Enum.TryParse(typeof(Character.Faction), faction, out object factionObj);

            if (!validFaction)
            {
                throw new ArgumentException($"Invalid faction \"{faction}\"!");
            }

            if (characterType != "Warrior" && characterType != "Cleric")
            {
                throw new ArgumentException($"Invalid character type \"{ characterType }\"!");
            }

            if (characterType == "Warrior")
            {
                character = new Warrior(name, (Character.Faction)factionObj);
            }
            else if (characterType == "Cleric")
            {
                character = new Cleric(name, (Character.Faction)factionObj);
            }
            return character;
        }
    }
