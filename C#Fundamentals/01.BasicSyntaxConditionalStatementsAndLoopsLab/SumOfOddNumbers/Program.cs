using System;

namespace SumOfOddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 1; i <= number; i++)
            {
                Console.WriteLine($"{2 * i - 1}");
                sum += 2 * i - 1;
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
