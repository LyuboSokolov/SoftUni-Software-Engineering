using System;
using System.Collections.Generic;
using System.Linq;

namespace MovingTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();

            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (input[0]?.ToUpper() != "END")
            {
                string command = input[0].ToUpper();
                int index = int.Parse(input[1]);
                int value = int.Parse(input[2]);

                if (command == "SHOOT")
                {
                    if (index >= 0 && index < targets.Count)
                    {
                        targets[index] -= value;
                        if (targets[index] <= 0)
                        {
                            targets.RemoveAt(index);
                        }
                    }
                }
                else if (command == "ADD")
                {
                    if (index >= 0 && index < targets.Count)
                    {
                        targets.Insert(index, value);
                    }
                    else
                    {
                        Console.WriteLine($"Invalid placement!");
                    }

                }
                else if (command == "STRIKE")
                {
                    if ((index >= 0 && index < targets.Count) && index - value >= 0 && index + value < targets.Count)
                    {
                        targets.RemoveRange(index - value, (value * 2) + 1);
                    }
                    else
                    {
                        Console.WriteLine($"Strike missed!");
                    }
                }

                input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            }
            Console.WriteLine(string.Join('|', targets));
        }
    }
}
