using System;
using System.Collections.Generic;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> dress = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ");
                string color = input[0];
                string inputDress = input[1];
                string[] splittedDress = inputDress.Split(",");

                if (!dress.ContainsKey(color))
                {
                    dress.Add(color, new Dictionary<string, int>());
                }

                for (int j = 0; j < splittedDress.Length; j++)
                {
                    if (!dress[color].ContainsKey(splittedDress[j]))
                    {
                        dress[color].Add(splittedDress[j], 0);
                    }
                    dress[color][splittedDress[j]]++;
                }
            }
            string[] findColorDress = Console.ReadLine().Split();
            string findGolor = findColorDress[0];
            string findDress = findColorDress[1];

            foreach (var currColor in dress)
            {
                Console.WriteLine($"{currColor.Key} clothes:");

                foreach (var currDress in currColor.Value)
                {
                    if (currColor.Key == findGolor && currDress.Key == findDress)
                    {
                        Console.WriteLine($"* {currDress.Key} - {currDress.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {currDress.Key} - {currDress.Value}");
                    }

                }
            }
        }
    }
}
