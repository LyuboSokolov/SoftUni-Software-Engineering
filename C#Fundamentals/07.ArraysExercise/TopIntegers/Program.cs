using System;
using System.Linq;

namespace TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();
            int V = numbers.Length;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (i + 1 < numbers.Length)
                {
                    if (numbers[i] > numbers[i + 1])
                    {
                        Console.Write($"{numbers[i]} ");
                    }
                }
                else
                {
                    Console.Write($"{numbers[numbers.Length - 1]}");
                }
            }
        }
    }
}
