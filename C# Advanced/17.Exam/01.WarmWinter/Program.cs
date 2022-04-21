using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.WarmWinter
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

           List<int> scarfs = new List<int>(Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList());

            List<int> sets = new List<int>();

            while (hats.Count > 0 && scarfs.Count >0)
            {
                int hat = hats.Pop();
                int scarf = scarfs[0];

                if (hat > scarf)
                {
                    sets.Add(hat + scarf);
                    scarfs.Remove(scarf);
                }
                else if (hat == scarf)
                {
                    hats.Push(hat + 1);
                    scarfs.Remove(scarf);
                }
            }
            int maxSet = 0;

            foreach (var set in sets)
            {
                if (maxSet < set)
                {
                    maxSet = set;
                }
            }

            Console.WriteLine($"The most expensive set is: {maxSet}");
            Console.WriteLine(string.Join(" ",sets));
        }
    }
}
