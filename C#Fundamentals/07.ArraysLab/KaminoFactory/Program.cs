﻿using System;

namespace KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string input = string.Empty;
            int bestCount = 0;
            int counter = 0;
            int bestBeginIndex = 0;
            int bestSum = 0;
            string bestSequence = string.Empty;
            int bestCounter = 0;

            while ((input = Console.ReadLine()) != "Clone them!")
            {
                string sequence = input.Replace("!", "");

                string[] dnaParts = sequence.Split("0", StringSplitOptions.RemoveEmptyEntries);

                int count = 0;
                int sum = 0;
                string bestSubSequence = string.Empty;
                counter++;

                foreach (var dnaPart in dnaParts)
                {
                    if (dnaPart.Length > count)
                    {
                        count = dnaPart.Length;
                        bestSubSequence = dnaPart;
                    }
                    sum += dnaPart.Length;
                }
                int beginIndex = sequence.IndexOf(bestSubSequence);

                if (count > bestCount ||
                   (count == bestCount && beginIndex < bestBeginIndex) ||
                   (count == bestBeginIndex && beginIndex == bestBeginIndex && sum > bestSum) || counter == 1)
                {
                    bestCount = count;
                    bestSequence = sequence;
                    bestBeginIndex = beginIndex;
                    bestSum = sum;
                    bestCounter = counter;
                }
            }
            char[] results = bestSequence.ToCharArray();

            Console.WriteLine($"Best DNA sample {bestCounter} with sum: {bestSum}.");
            Console.WriteLine($"{string.Join(" ", results)}");
        }
    }
}
