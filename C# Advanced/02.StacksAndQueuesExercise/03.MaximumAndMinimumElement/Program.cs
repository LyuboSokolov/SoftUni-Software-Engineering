using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                int command = input[0];

                if (command == 1)
                {
                    numbers.Push(input[1]);
                }
                else if (command == 2 && numbers.Count > 0)
                {
                    numbers.Pop();
                }
                else if (command == 3 && numbers.Count > 0)
                {
                    Console.WriteLine(numbers.Max());
                }
                else if (command == 4 && numbers.Count > 0)
                {
                    Console.WriteLine(numbers.Min());
                }
            }
                        Console.WriteLine(string.Join(", ",numbers));
        }
    }
}
