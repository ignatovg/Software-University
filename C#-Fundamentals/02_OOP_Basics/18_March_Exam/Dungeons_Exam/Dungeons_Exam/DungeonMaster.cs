using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dungeons_Exam.Characters;
using Dungeons_Exam.Factories;
using Dungeons_Exam.Items;

namespace Dungeons_Exam
{
    public class DungeonMaster
    {
        public List<Character> party;
        public List<Item> itemPoll;
        public CharacterFactory characterFactory;
        public ItemFactory ItemFactory;

        private int rounds = 0;

        public DungeonMaster()
        {
            party = new List<Character>();
            characterFactory = new CharacterFactory();
            ItemFactory = new ItemFactory();
            itemPoll = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            string name = args[2];
            Character character = null;

            character = characterFactory.CreateCharacter(args);

            if (character != null)
            {
                party.Add(character);
                return $"{name} joined the party!";
            }
            return "";
        }

        public string AddItemToPool(string[] args)
        {
            Item item = null;
            string itemName = args[0];

            item = ItemFactory.CreateItem(args);

            if (item != null)
            {
                itemPoll.Add(item);
                return $"{itemName} added to pool.";
            }
            return "";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            if (!party.Any(m => m.Name == characterName))
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }
            if (itemPoll.Count == 0)
            {
                throw new InvalidOperationException($"No items left in pool!");
            }

            var lastItem = itemPoll.Last();

            var character = party.First(n => n.Name == characterName);
            character.ReceiveItem(lastItem);

            itemPoll.Remove(lastItem);

            //                                          posiivle bug
            return $"{characterName} picked up {lastItem.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            if (!party.Any(m => m.Name == characterName))
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }
            if (itemPoll.Count == 0)
            {
                throw new InvalidOperationException($"No items left in pool!");
            }
            var character = party.First(n => n.Name == characterName);

            character.Bag.GetItem(itemName);

            return $"{character.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];

            if (!party.Any(n => n.Name == giverName))
            {
                throw new ArgumentException($"Character {giverName} not found!");
            }
            if (!party.Any(n => n.Name == receiverName))
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }
            if (itemPoll.Count == 0)
            {
                throw new InvalidOperationException($"No items left in pool!");
            }

            var giverChar = party.Find(n => n.Name == giverName);
            var receiverChar = party.Find(n => n.Name == receiverName);

            //possible bug
            var item = giverChar.Bag.GetItem(itemName);

            giverChar.UseItemOn(item, receiverChar);

            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];

            if (!party.Any(n => n.Name == giverName))
            {
                throw new ArgumentException($"Character {giverName} not found!");
            }
            if (!party.Any(n => n.Name == receiverName))
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }
            if (itemPoll.Count == 0)
            {
                throw new InvalidOperationException($"No items left in pool!");
            }

            var giverChar = party.Find(n => n.Name == giverName);
            var receiverChar = party.Find(n => n.Name == receiverName);
            var item = giverChar.Bag.GetItem(itemName);

            giverChar.GiveCharacterItem(item, receiverChar);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            StringBuilder builder = new StringBuilder();

            foreach (Character character in party.OrderByDescending(a => a.IsAlive).ThenBy(h => h.Health))
            {
                builder.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {character.IsAlive}");
            }

            return builder.ToString();
        }

        public string Attack(string[] args)
        {
            var attackerName = args[0];
            var receiverName = args[1];

            if (!party.Any(n => n.Name == attackerName))
            {
                throw new ArgumentException($"Character {attackerName} not found!");
            }
            if (!party.Any(n => n.Name == receiverName))
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            var attackerChar = party.First(n => n.Name == attackerName);
            var receiverChar = party.First(n => n.Name == receiverName);

            if (attackerChar.GetType().Name != "Warrior")
            {
                throw new ArgumentException($"{attackerName} cannot attack!");
            }
            var warrior = (Warrior)attackerChar;
            warrior.Attack(receiverChar);

            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"{attackerName} attacks {receiverName} for {attackerChar.AbilityPoints} hit points!")
                .AppendLine($"{receiverName} has {receiverChar.Health}/{receiverChar.BaseHealth} HP and")
                .AppendLine($"{receiverChar.Armor}/{receiverChar.BaseArmor} AP left!");

            if (!receiverChar.IsAlive || receiverChar.Health <= 0)
            {
                party.Remove(receiverChar);
                builder.AppendLine($"{receiverName} is dead!");
            }

            return builder.ToString();
        }

        public string Heal(string[] args)
        {
            var healerName = args[1];
            var healingReceiverName = args[1];

            if (!party.Any(n => n.Name == healerName))
            {
                throw new ArgumentException($"Character {healerName} not found!");
            }
            if (!party.Any(n => n.Name == healingReceiverName))
            {
                throw new ArgumentException($"Character {healingReceiverName} not found!");
            }

            var healerChar = party.First(n => n.Name == healerName);
            var receiverChar = party.First(n => n.Name == healingReceiverName);

            if (healerChar.GetType().Name != "Cleric")
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }
            var healer = (Cleric)healerChar;
            healer.Heal(receiverChar);

            StringBuilder builder = new StringBuilder();
            builder.AppendLine(
                $"{healerName} heals {healingReceiverName} for {healer.AbilityPoints}! {healingReceiverName} has {receiverChar.Health} health now!");

            return builder.ToString();
        }

        public string EndTurn(string[] args)
        {
            StringBuilder builder = new StringBuilder();

            if (party.Any(n => n.IsRested))
            {
                foreach (Character character in party)
                {
                    builder.AppendLine($"“{character.Name} rests ({character.HealBefore} => {character.Health})");
                }
            }
            
            //if (party.Count == 1 || party.Count == 0)
            //{

            //}
            return builder.ToString();
        }

        public bool IsGameOver()
        {
            throw new NotImplementedException();
        }

    }
}
