using System;
using System.Collections.Generic;
using System.Linq;

namespace ListManipulationBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                         .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                         .Select(int.Parse)
                                         .ToList();

            string[] command = Console.ReadLine()
                                      .ToUpper()
                                      .Split()
                                      .ToArray();

            while (command[0] != "END")
            {
                switch (command[0])
                {
                    case "ADD":
                        numbers.Add(int.Parse(command[1]));
                        break;
                    case "REMOVE":
                        numbers.Remove(int.Parse(command[1]));
                        break;
                    case "REMOVEAT":
                        numbers.RemoveAt(int.Parse(command[1]));
                        break;
                    case "INSERT":
                        numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine()
                                      .ToUpper()
                                      .Split()
                                      .ToArray();
            }

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
