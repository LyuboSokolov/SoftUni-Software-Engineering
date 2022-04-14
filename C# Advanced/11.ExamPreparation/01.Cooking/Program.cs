using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> ingredients = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int breadCount = 0;
            int cakeCount = 0;
            int pastryCount = 0;
            int fruitPieCount = 0;
            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int liquid = liquids.Dequeue();
                int ingredient = ingredients.Pop();
                int sum = liquid + ingredient;

                if (sum == 100)
                {
                    fruitPieCount++;
                }
                else if (sum == 75)
                {
                    pastryCount++;
                }
                else if (sum == 50)
                {
                    cakeCount++;
                }
                else if (sum == 25)
                {
                    breadCount++;
                }
                else
                {
                    ingredients.Push(ingredient + 3);
                }
            }

            if (breadCount >= 1 && cakeCount >= 1 && pastryCount >= 1 && fruitPieCount >= 1)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }

            if (ingredients.Count == 0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }
            Console.WriteLine($"Bread: {breadCount}");
            Console.WriteLine($"Cake: {cakeCount}");
            Console.WriteLine($"Fruit Pie: {fruitPieCount}");
            Console.WriteLine($"Pastry: {pastryCount}");

        }
    }
}
