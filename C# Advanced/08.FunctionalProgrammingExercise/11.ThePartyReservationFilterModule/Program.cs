using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> filters = new List<string>();

            string input = Console.ReadLine();

            while (input != "Print")
            {
                string[] tokens = input.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                string filterType = tokens[1];
                string filterParameter = tokens[2];

                if (command == "Add filter")
                {
                    filters.Add($"{filterType};{filterParameter}");
                }
                else if (command == "Remove filter")
                {
                    filters.Remove($"{filterType};{filterParameter}");
                }

                input = Console.ReadLine();
            }

            foreach (var filter in filters)
            {
                string[] tokens = filter.Split(";");
                string filterType = tokens[0];
                string filterParameter = tokens[1];

                switch (filterType)
                {
                    case "Starts with":
                        people = people.Where(x => !x.StartsWith(filterParameter)).ToList();
                        break;
                    case "Ends with":
                        people = people.Where(x => !x.EndsWith(filterParameter)).ToList();
                        break;
                    case "Length":
                        people = people.Where(x => x.Length != (int.Parse(filterParameter))).ToList();
                        break;
                    case "Contains":
                        people = people.Where(x => !x.Contains(filterParameter)).ToList();
                        break;
                }
            }

            Console.WriteLine(string.Join(" ",people));
        }
    }
}
