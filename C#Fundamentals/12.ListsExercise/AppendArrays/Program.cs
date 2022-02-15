using System;
using System.Collections.Generic;
using System.Linq;

namespace AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine()
                .Split('|')
                .ToList();

            numbers.Reverse();
            List<string> results = new List<string>();

            foreach (string number in numbers)
            {

                string[] currentNumber = number
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                foreach (string nuberToAdd in currentNumber)
                {
                    results.Add(nuberToAdd);
                }
            }

            Console.WriteLine(string.Join(' ', results));
        }
    }
}
