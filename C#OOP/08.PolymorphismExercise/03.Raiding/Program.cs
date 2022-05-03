using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<BaseHero> heroes = new List<BaseHero>();

            for (int i = 0; i < n; i++)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                BaseHero hero = CreateHero(heroName, heroType);

                if (hero == null)
                {
                    Console.WriteLine("Invalid hero!");
                    i--;
                    continue;
                }


                heroes.Add(hero);
            }

            int bossPower = int.Parse(Console.ReadLine());

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            if (bossPower <= heroes.Sum(h => h.Power))
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }

        private static BaseHero CreateHero(string heroName, string heroType)
        {
            BaseHero hero = null;

            if (heroType == nameof(Druid))
            {
                hero = new Druid(heroName);
            }
            else if (heroType == nameof(Paladin))
            {
                hero = new Paladin(heroName);
            }
            else if (heroType == nameof(Rogue))
            {
                hero = new Rogue(heroName);
            }
            else if (heroType == nameof(Warrior))
            {
                hero = new Warrior(heroName);
            }

            return hero;
        }
    }
}
