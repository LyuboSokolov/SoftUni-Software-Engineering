using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstLootBox = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Stack<int> secondLootBox = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int qualityOfItems = 0;
            bool firstLoodEmpty = false;

            while (firstLootBox.Count > 0 && secondLootBox.Count > 0)
            {
                int itemFromFirstLoot = firstLootBox[0];
                int itemFromSecondLoot = secondLootBox.Pop();

                if ((itemFromFirstLoot + itemFromSecondLoot) % 2 == 0)
                {
                    qualityOfItems += itemFromFirstLoot;
                    qualityOfItems += itemFromSecondLoot;
                    firstLootBox.Remove(itemFromFirstLoot);
                }
                else
                {
                    firstLootBox.Add(itemFromSecondLoot);
                }

                if (firstLootBox.Count == 0)
                {
                    firstLoodEmpty = true;
                    break;
                }
                
            }

            if (firstLoodEmpty)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (qualityOfItems >= 100 )
            {
                Console.WriteLine($"Your loot was epic! Value: {qualityOfItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {qualityOfItems}");
            }
        }
    }
}
