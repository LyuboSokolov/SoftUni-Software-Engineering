using System;
using System.Linq;

namespace RoundingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
               .Split()
               .Select(double.Parse)
               .ToArray();
            double[] numbersRound = new double[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == -0)
                {
                    numbers[i] = 0;
                }
                numbersRound[i] = (int)Math.Round(numbers[i], MidpointRounding.AwayFromZero);
                Console.WriteLine($"{numbers[i]} => {numbersRound[i]}");
            }
        }
    }
}
