using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(=|\/)(?<destination>[A-Z][A-Za-z]{2,})\1";

            string input = Console.ReadLine();

            Regex regex = new Regex(pattern);
            MatchCollection mathes = regex.Matches(input);

            List<string> results = new List<string>();
            int travelPoints = 0;

            foreach (Match match in mathes)
            {
                results.Add(match.Groups["destination"].Value);
                travelPoints += match.Groups["destination"].Value.Length;
            }

            Console.WriteLine($"Destinations: {string.Join(", ", results)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
