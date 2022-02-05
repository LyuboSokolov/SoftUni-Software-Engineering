using System;
using System.Linq;

namespace MagicSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToArray();
            int givenNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < arr.Length; i++)
            {
                int currentNumber = arr[i];
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (currentNumber + arr[j] == givenNumber)
                    {
                        Console.WriteLine($"{currentNumber} {arr[j]}");
                    }
                }
            }
        }
    }
}
