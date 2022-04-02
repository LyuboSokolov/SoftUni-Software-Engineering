using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int lowerBound = range[0];
            int upperBound = range[1];

            string oddOrEven = Console.ReadLine();

            Func<int, int, List<int>> numbers = (l, u) =>
              {
                  List<int> numbers = new List<int>();
                  for (int i = l; i <= u; i++)
                  {
                      numbers.Add(i);
                  }
                  return numbers;
              };
            List<int> allNumbers = numbers(lowerBound, upperBound);
            Predicate<int> predicat = x => true;

            if (oddOrEven == "odd")
            {
                predicat = x => x % 2 != 0;
            }
            else if (oddOrEven == "even")
            {
                predicat = x => x % 2 == 0;
            }

            Console.WriteLine(string.Join(" ", MyWhere(allNumbers, predicat)));
        }

        static List<int> MyWhere(List<int> numbers, Predicate<int> predicat)
        {
            List<int> newNumbers = new List<int>();

            foreach (var number in numbers)
            {
                if (predicat(number))
                {
                    newNumbers.Add(number);
                }
            }
            return newNumbers;
        }
    }
}
