using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .ToLower()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> items = new Dictionary<string, int>();

            items["shards"] = 0;
            items["fragments"] = 0;
            items["motes"] = 0;
            Dictionary<string, int> junkItems = new Dictionary<string, int>();

            bool isObtained = false;

            while (true)
            {
                for (int i = 0; i < input.Length; i += 2)
                {
                    int quantity = int.Parse(input[i]);
                    string item = input[i + 1];

                    if (items.ContainsKey(item))
                    {
                        items[item] += quantity;

                        if (items.ContainsKey("shards") && items["shards"] >= 250)
                        {
                            Console.WriteLine("Shadowmourne obtained!");
                            isObtained = true;
                            items["shards"] -= 250;
                            break;
                        }
                        if (items.ContainsKey("fragments") && items["fragments"] >= 250)
                        {
                            Console.WriteLine("Valanyr obtained!");
                            isObtained = true;
                            items["fragments"] -= 250;
                            break;

                        }

                        if (items.ContainsKey("motes") && items["motes"] >= 250)
                        {
                            Console.WriteLine("Dragonwrath obtained!");
                            isObtained = true;
                            items["motes"] -= 250;
                            break;
                        }
                    }
                    else
                    {
                        if (junkItems.ContainsKey(item) == false)
                        {
                            junkItems.Add(item, 0);
                        }
                        junkItems[item] += quantity;
                    }
                }

                if (isObtained)
                {
                    break;
                }

                input = Console.ReadLine()
                .ToLower()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            Dictionary<string, int> filtredItems = items
                 .OrderByDescending(a => a.Value)
                 .ThenBy(a => a.Key)
                 .ToDictionary(a => a.Key, a => a.Value);

            foreach (var item in filtredItems)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            foreach (var item in junkItems.OrderBy(n => n.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
