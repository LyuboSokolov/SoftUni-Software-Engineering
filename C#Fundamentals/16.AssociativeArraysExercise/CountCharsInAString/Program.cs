using System;
using System.Collections.Generic;

namespace CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Dictionary<char, int> characters = new Dictionary<char, int>();

            foreach (var word in words)
            {
                foreach (char letter in word)
                {
                    if (characters.ContainsKey(letter))
                    {
                        characters[letter]++;
                    }
                    else
                    {
                        characters.Add(letter, 1);
                    }
                }
            }

            foreach (var chars in characters)
            {
                Console.WriteLine($"{chars.Key} -> {chars.Value}");
            }
        }
    }
}
