using System;
using System.Collections.Generic;
using System.Linq;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToList();
            int maxCapacity = int.Parse(Console.ReadLine());

            string[] input = Console.ReadLine()
                .Split()
                .ToArray();

            int freeSeats = 0;

            while (input[0] != "end")
            {
                if (input[0] == "Add")
                {
                    wagons.Add(int.Parse(input[1]));
                }
                else
                {
                    int passagers = int.Parse(input[0]);

                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i] < maxCapacity)
                        {
                            freeSeats = maxCapacity - wagons[i];

                            if (passagers <= freeSeats)
                            {
                                wagons[i] += passagers;
                                break;
                            }
                                                    }
                    }
                }

                input = Console.ReadLine()
               .Split()
               .ToArray();
            }

            Console.WriteLine(string.Join(' ', wagons));
        }
    }
}
