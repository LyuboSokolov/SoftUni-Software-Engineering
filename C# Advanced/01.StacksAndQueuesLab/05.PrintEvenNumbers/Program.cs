using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Queue<int> evenNumbers = new Queue<int>(input.Where(n => n % 2 == 0));

            Console.WriteLine(string.Join(", ",evenNumbers));
        }
    }
}
