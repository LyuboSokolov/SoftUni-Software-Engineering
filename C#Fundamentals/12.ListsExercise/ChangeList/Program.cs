using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string[] commands = Console.ReadLine()
                .ToUpper()
                .Split()
                .ToArray();

            while (commands[0] != "END")
            {
                if (commands[0] == "DELETE")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] == int.Parse(commands[1]))
                        {
                            numbers.Remove(numbers[i]);
                            i--;
                        }
                    }
                }
                else if (commands[0] == "INSERT")
                {
                    numbers.Insert(int.Parse(commands[2]), int.Parse(commands[1]));
                }

                commands = Console.ReadLine()
                .ToUpper()
                .Split()
                .ToArray();
            }

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
