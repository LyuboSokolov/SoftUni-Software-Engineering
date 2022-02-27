using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
               .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> namesAndScore = new Dictionary<string, int>();

            foreach (var name in names)
            {
                namesAndScore.Add(name, 0);
            }

            string namePattern = @"[\W\d]";
            string scorePattern = @"[\WA-Za-z]";


            string input = Console.ReadLine();

            while (input != "end of race")
            {
                string currentName = Regex.Replace(input, namePattern, "");
                string currentScore = Regex.Replace(input, scorePattern, "");
                int sum = 0;

                foreach (var digit in currentScore)
                {
                    sum += int.Parse(digit.ToString());
                }

                if (namesAndScore.ContainsKey(currentName))
                {
                    namesAndScore[currentName] += sum;
                }


                input = Console.ReadLine();
            }
            int count = 1;
            foreach (var name in namesAndScore.OrderByDescending(k => k.Value))
            {
                string text = count == 1 ? "st" : count == 2 ? "nd" : "rd";

                Console.WriteLine($"{count++}{text} place: {name.Key}");

                if (count == 4)
                {
                    break;
                }
            }
        }
    }
}
