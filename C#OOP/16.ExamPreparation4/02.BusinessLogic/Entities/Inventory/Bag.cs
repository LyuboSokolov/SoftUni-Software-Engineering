using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private int capacity = 100;
        private List<Item> items;

        public Bag(int capacity)
        {
            Capacity = capacity;
            items = new List<Item>();
        }
        public int Capacity
        {
            get => capacity;
            set
            {
                capacity = value;
            }
        }

        public int Load
        {
            get => Items.Sum(p => p.Weight);
        }

        public IReadOnlyCollection<Item> Items { get => items; }

        public void AddItem(Item item)
        {
            if (items.Sum(p => p.Weight) + item.Weight > Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }
            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }
            if (items.Any(p=>p.GetType().Name == name) == false)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            Item item = items.FirstOrDefault(p => p.GetType().Name == name);
            items.Remove(item);
            return item;
        }
    }
}
