using System;
using System.Collections.Generic;
using System.Linq;

namespace PlantDiscovery
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> plants = new Dictionary<string, Dictionary<string, double>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputPlants = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries);
                string plant = inputPlants[0];
                double rarity = double.Parse(inputPlants[1]);

                if (plants.ContainsKey(plant))
                {
                    plants[plant]["rarity"] = rarity;
                }
                else
                {
                    plants.Add(plant, new Dictionary<string, double>
                    {
                        {"rarity",rarity},
                        {"rating",0},
                        {"count",0}
                    });

                }
            }

            string input = Console.ReadLine();

            while (input != "Exhibition")
            {
                string[] tokens = input.Split(": ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                string[] plantAndRarity = tokens[1].Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string plant = plantAndRarity[0];

                if (command == "Rate")
                {
                    int rating = int.Parse(plantAndRarity[1]);
                    if (plants.ContainsKey(plant))
                    {
                        plants[plant]["rating"] += rating;
                        plants[plant]["count"]++;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }

                }
                else if (command == "Update")
                {
                    int newRarity = int.Parse(plantAndRarity[1]);

                    if (plants.ContainsKey(plant))
                    {
                        plants[plant]["rarity"] = newRarity;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (command == "Reset")
                {
                    if (plants.ContainsKey(plant))
                    {
                        plants[plant]["rating"] = 0;
                        plants[plant]["count"] = 0;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }

                input = Console.ReadLine();
            }
            Console.WriteLine("Plants for the exhibition:");

            foreach (var plant in plants.OrderByDescending(n => n.Value["rarity"]).ThenByDescending(n => n.Value["rating"] / n.Value["count"]))
            {
                if (plant.Value["rating"] > 0)
                {
                    Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value["rarity"]}; Rating: {plant.Value["rating"] / plant.Value["count"]:f2}");
                }
                else
                {
                    Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value["rarity"]}; Rating: 0.00");
                }
            }
        }
    }
}
