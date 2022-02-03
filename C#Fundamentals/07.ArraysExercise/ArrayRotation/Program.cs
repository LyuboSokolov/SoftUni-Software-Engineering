using System;
using System.Linq;

namespace ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int rotation = int.Parse(Console.ReadLine());

            for (int i = 0; i < rotation; i++)
            {
                int firstnumber = numbers[0];

                for (int j = 1; j < numbers.Length; j++)
                {
                    int currentNumber = numbers[j];
                    numbers[j - 1] = currentNumber;
                }
                numbers[numbers.Length - 1] = firstnumber;
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
