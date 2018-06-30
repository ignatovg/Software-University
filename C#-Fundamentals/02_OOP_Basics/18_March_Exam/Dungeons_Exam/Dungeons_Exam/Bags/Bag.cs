using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dungeons_Exam.Items;

namespace Dungeons_Exam.Bags
{
    public abstract class Bag
    {
        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            bags= new List<Item>();
        }


        public List<Item> bags;
        public  int Capacity { get; } = 100;
        public IReadOnlyCollection<Item> Items { get; }
        public int Load => Items.Sum(w => w.Weight);

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }
             bags.Add(item);
           
        }

        public Item GetItem(string name)
        {
            if (bags.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }
            foreach (Item item in bags)
            {
                if (item is ArmorRepairKit)
                {
                    bags.Remove(item);
                    return item;
                }
                else if (item is HealthPotion)
                {
                    bags.Remove(item);
                    return item;
                }
                else if (item is PoisonPotion)
                {
                    bags.Remove(item);
                    return item;
                }
            }
            throw new InvalidOperationException($"No item with name {name} in bag!");


        }

    }
}
