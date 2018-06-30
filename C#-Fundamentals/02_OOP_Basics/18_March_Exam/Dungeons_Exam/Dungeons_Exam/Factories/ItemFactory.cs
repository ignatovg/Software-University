using System;
using System.Collections.Generic;
using System.Text;
using Dungeons_Exam.Items;


    public class ItemFactory
    {
        public Item CreateItem(string[] args)
        {
            string itemName = args[0];

            Item item = null;
            if (itemName == "ArmorRepairKit")
            {
                item = new ArmorRepairKit();
                return item;
            }
            else if (itemName == "HealthPotion")
            {
                item = new HealthPotion();
                return item;
            }
            else if (itemName == "PoisonPotion")
            {
                item = new PoisonPotion();
                return item;
            }
            throw new ArgumentException($"Invalid item \"{ itemName }\"");
        }
    }

