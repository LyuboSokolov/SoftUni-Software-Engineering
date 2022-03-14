using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
              .Split()
              .Select(int.Parse)
              .ToArray();
            int n = input[0];
            int dequeueEments = input[1];
            int number = input[2];

            Queue<int> numbers = new Queue<int>();
            int[] numberInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < n; i++)
            {
                numbers.Enqueue(numberInput[i]);
            }

            for (int i = 0; i < dequeueEments; i++)
            {
                numbers.Dequeue();
            }

            if (numbers.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (numbers.Contains(number))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(numbers.Min());
            }
        }
    }
}
