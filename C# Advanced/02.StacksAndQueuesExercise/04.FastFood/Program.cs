using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityFood = int.Parse(Console.ReadLine());
            int[] sequenceOrder = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Queue<int> orders = new Queue<int>(sequenceOrder);
            Console.WriteLine(orders.Max());

            while (quantityFood > 0 && orders.Count > 0)
            {
                if (orders.Peek() <= quantityFood)
                {
                    quantityFood -= orders.Dequeue();
                }
                else
                {
                    break;
                }
            }
            if (orders.Count > 0)
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
