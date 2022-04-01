using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> smallestNumber = GetSmallestNumber;

            Console.WriteLine(smallestNumber(numbers)); 
        }

        static int GetSmallestNumber(int[] numbers)
        {
            int minValue = int.MaxValue;

            foreach (var number in numbers)
            {
                if (number < minValue)
                {
                    minValue = number;
                }
            }

            return minValue;
        }
    }
}
