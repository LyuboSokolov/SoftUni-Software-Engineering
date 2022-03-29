using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, SortedSet<string>>> vloggers = new Dictionary<string, Dictionary<string, SortedSet<string>>>();


            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                string[] nameAndCommand = input.Split();
                string name = nameAndCommand[0];
                string command = nameAndCommand[1];

                if (command == "joined")
                {
                    if (!vloggers.ContainsKey(name))
                    {
                        vloggers.Add(name, new Dictionary<string, SortedSet<string>>());
                        vloggers[name].Add("followers", new SortedSet<string>());
                        vloggers[name].Add("following", new SortedSet<string>());
                    }
                }
                 else if (command == "followed")
                {
                    string secondName = nameAndCommand[2];

                    if (vloggers.ContainsKey(name) && vloggers.ContainsKey(secondName) && name != secondName)
                    {
                        if (!vloggers[secondName]["followers"].Contains(name))
                        {
                            vloggers[secondName]["followers"].Add(name);
                            vloggers[name]["following"].Add(secondName);
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
            int count = 0;
            foreach (var vlogger in vloggers.OrderByDescending(x => x.Value["followers"].Count).ThenBy(x => x.Value["following"].Count))
            {
                count++;

                Console.WriteLine($"{count}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");
                if (count == 1)
                {
                    foreach (var currentVlogger in vlogger.Value["followers"])
                    {
                        Console.WriteLine($"*  {currentVlogger}");
                    }
                }
            }
        }
    }
}
