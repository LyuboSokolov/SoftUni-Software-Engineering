using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(@|#){1}(?<firstWord>[A-Za-z]{3,})\1{2}(?<secondWord>[A-Za-z]{3,})\1{1}";

            string input = Console.ReadLine();

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);

            List<string> results = new List<string>();

            if (matches.Count > 0)
            {
                Console.WriteLine($"{matches.Count} word pairs found!");

                foreach (Match match in matches)
                {
                    string firstWord = match.Groups["firstWord"].Value;
                    string secondWord = match.Groups["secondWord"].Value;
                    string mirrorWord = new string(firstWord.Reverse().ToArray());

                    if (secondWord == mirrorWord)
                    {
                        results.Add($"{firstWord} <=> {secondWord}");
                    }

                }

                if (results.Count > 0)
                {
                    Console.WriteLine($"The mirror words are:");
                    Console.WriteLine(string.Join(", ", results));
                }
                else
                {
                    Console.WriteLine("No mirror words!");
                }
            }
            else
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
            }
        }
    }
}
