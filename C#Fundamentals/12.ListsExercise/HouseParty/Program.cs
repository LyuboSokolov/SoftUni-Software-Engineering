using System;
using System.Collections.Generic;
using System.Linq;

namespace HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> guest = new List<string>(n);

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split()
                    .ToArray();

                string currentName = input[0];

                if (guest.Contains(currentName))
                {
                    if (input[2] == "not")
                    {
                        guest.Remove(currentName);
                    }
                    else
                    {
                        Console.WriteLine($"{currentName} is already in the list!");
                    }
                }
                else
                {
                    if (input[2] == "not")
                    {
                        Console.WriteLine($"{currentName} is not in the list!");
                    }
                    else
                    {
                        guest.Add(currentName);
                    }
                }
            }

            for (int i = 0; i < guest.Count; i++)
            {
                Console.WriteLine(guest[i]);
            }
        }
    }
}
