using System;
using System.Linq;

namespace _02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] names = input.Select(x => $"Sir {x}").ToArray();

            Action<string[]> printNames = x => Console.WriteLine(string.Join(Environment.NewLine, x));

            printNames(names);
        }
    }
}
