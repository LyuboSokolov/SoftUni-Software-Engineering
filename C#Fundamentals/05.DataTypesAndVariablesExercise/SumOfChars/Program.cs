using System;

namespace SumOfChars
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < numbers; i++)
            {
                char input = char.Parse(Console.ReadLine());

                sum += input;
            }
            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
