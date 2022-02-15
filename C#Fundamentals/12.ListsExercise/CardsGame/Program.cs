using System;
using System.Collections.Generic;
using System.Linq;

namespace CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayerCards = Console.ReadLine()
              .Split(' ', StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToList();

            List<int> secondPlayerCards = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (firstPlayerCards.Count > 0 && secondPlayerCards.Count > 0)
            {




                if (firstPlayerCards[0] > secondPlayerCards[0])
                {
                    firstPlayerCards.Add(firstPlayerCards[0]);
                    firstPlayerCards.RemoveAt(0);
                    firstPlayerCards.Add(secondPlayerCards[0]);
                    secondPlayerCards.RemoveAt(0);
                }
                else if (firstPlayerCards[0] < secondPlayerCards[0])
                {
                    secondPlayerCards.Add(secondPlayerCards[0]);
                    secondPlayerCards.RemoveAt(0);
                    secondPlayerCards.Add(firstPlayerCards[0]);
                    firstPlayerCards.RemoveAt(0);
                }
                else if (firstPlayerCards[0] == secondPlayerCards[0])
                {
                    firstPlayerCards.RemoveAt(0);
                    secondPlayerCards.RemoveAt(0);
                }



            }

            if (firstPlayerCards.Count < secondPlayerCards.Count)
            {
                Console.WriteLine($"Second player wins! Sum: {secondPlayerCards.Sum()}");
            }
            else if (secondPlayerCards.Count < firstPlayerCards.Count)
            {
                Console.WriteLine($"First player wins! Sum: {firstPlayerCards.Sum()}");
            }
        }
    }
}
