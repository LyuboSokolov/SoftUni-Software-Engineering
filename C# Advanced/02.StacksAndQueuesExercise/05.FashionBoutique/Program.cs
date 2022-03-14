using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int capacityRack = int.Parse(Console.ReadLine());

            int capacity = capacityRack;
            Stack<int> numbers = new Stack<int>(input);
            int countRack = 1;

            while (numbers.Count > 0)
            {
                if (numbers.Peek() <= capacityRack)
                {
                    capacityRack -= numbers.Pop();
                }
                else
                {
                    countRack++;
                    capacityRack = capacity;
                    capacityRack -= numbers.Pop();
                }
            }
            Console.WriteLine(countRack);
        }
    }
}
