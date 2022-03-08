using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroesOfCodeAndLogicVII
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> heroes = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputHero = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = inputHero[0];
                int healt = int.Parse(inputHero[1]);
                int mana = int.Parse(inputHero[2]);


                heroes.Add(name, new Dictionary<string, int>()
                    {
                        {"healt",healt},
                        {"mana",mana}
                    });
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                string name = tokens[1];
                int amount = 0;
                switch (command)
                {
                    case "CastSpell":
                        int manaNeeded = int.Parse(tokens[2]);
                        string spellName = tokens[3];

                        if (heroes[name]["mana"] >= manaNeeded)
                        {
                            heroes[name]["mana"] -= manaNeeded;
                            Console.WriteLine($"{name} has successfully cast {spellName} and now has { heroes[name]["mana"]} MP!");
                        }
                        else
                        {
                            Console.WriteLine($"{name} does not have enough MP to cast {spellName}!");
                        }
                        break;

                    case "TakeDamage":
                        int damage = int.Parse(tokens[2]);
                        string attacker = tokens[3];

                        if (heroes[name]["healt"] - damage > 0)
                        {
                            heroes[name]["healt"] -= damage;
                            Console.WriteLine($"{name} was hit for {damage} HP by {attacker} and now has {heroes[name]["healt"]} HP left!");
                        }
                        else
                        {
                            Console.WriteLine($"{name} has been killed by {attacker}!");
                            heroes.Remove(name);
                        }
                        break;

                    case "Recharge":
                        amount = int.Parse(tokens[2]);

                        if (heroes[name]["mana"] + amount <= 200)
                        {
                            heroes[name]["mana"] += amount;
                            Console.WriteLine($"{name} recharged for {amount} MP!");
                        }
                        else
                        {
                            Console.WriteLine($"{name} recharged for {200 - heroes[name]["mana"]} MP!");
                            heroes[name]["mana"] = 200;
                        }
                        break;

                    case "Heal":
                        amount = int.Parse(tokens[2]);

                        if (heroes[name]["healt"] + amount <= 100)
                        {
                            heroes[name]["healt"] += amount;
                            Console.WriteLine($"{name} healed for {amount} HP!");
                        }
                        else
                        {
                            Console.WriteLine($"{name} healed for {100 - heroes[name]["healt"]} HP!");
                            heroes[name]["healt"] = 100;
                        }
                        break;

                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            heroes = heroes.OrderByDescending(n => n.Value["healt"]).ThenBy(n => n.Key).ToDictionary(n => n.Key, n => n.Value);

            foreach (var hero in heroes)
            {
                Console.WriteLine($"{hero.Key}");
                Console.WriteLine($"HP: {hero.Value["healt"]}");
                Console.WriteLine($"MP: {hero.Value["mana"]}");
            }
        }
    }
}
