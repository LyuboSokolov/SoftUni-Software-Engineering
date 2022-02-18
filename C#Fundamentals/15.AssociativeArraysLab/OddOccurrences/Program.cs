using System;
using System.Collections.Generic;

namespace OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
               .ToLower()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> oddWords = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (oddWords.ContainsKey(word))
                {
                    oddWords[word]++;
                }
                else
                {
                    oddWords.Add(word, 1);
                }
            }

            foreach (var word in oddWords)
            {
                if (word.Value % 2 == 1)
                {
                    Console.Write($"{word.Key} ");
                }
            }
        }
    }
}
