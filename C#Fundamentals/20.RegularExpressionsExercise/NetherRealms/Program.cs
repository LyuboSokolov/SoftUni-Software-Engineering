using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NetherRealms
{
    class Demon
    {
        public string Name { get; set; }
        public int Healt { get; set; }
        public double Damage { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Healt} health, {Damage} damage";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Demon> allDemons = new List<Demon>();

            string pattern = @"[-+]?[0-9]+\.?[0-9]*";

            Regex numberRegex = new Regex(pattern);

            string[] demons = Console.ReadLine()
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var demon in demons)
            {
                string filter = "0123456789+-/*.";
                int healt = demon.Where(n => !filter.Contains(n)).Sum(n => n);
                double damage = Damage(numberRegex, demon);

                allDemons.Add(new Demon() { Name = demon, Healt = healt, Damage = damage });
            }

            foreach (var demon in allDemons.OrderBy(n => n.Name))
            {
                Console.WriteLine($"{demon.Name} - {demon.Healt} health, {demon.Damage:f2} damage");
            }
        }

        private static double Damage(Regex numberRegex, string demon)
        {
            MatchCollection matches = numberRegex.Matches(demon);
            double damages = 0;

            foreach (Match item in matches)
            {
                damages += double.Parse(item.Value); ;
            }

            foreach (var ch in demon)
            {
                if (ch == '*')
                {
                    damages *= 2;
                }
                else if (ch == '/')
                {
                    damages /= 2;
                }
            }

            return damages;
        }
    }
}
