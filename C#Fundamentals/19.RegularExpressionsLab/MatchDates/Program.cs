using System;
using System.Text.RegularExpressions;

namespace MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = Console.ReadLine();

            string pattern = @"\b(?<day>\d{2})(\.*\-*\/*)(?<month>[A-Z][a-z]{2})\1(?<year>[0-9]{4})\b";
            Regex regex = new Regex(pattern);
            var matches = regex.Matches(data);

            foreach (Match match in matches)
            {
                Console.WriteLine($"Day: {match.Groups["day"]}, Month: {match.Groups["month"]}, Year: {match.Groups["year"]}");
            }
        }
    }
}
