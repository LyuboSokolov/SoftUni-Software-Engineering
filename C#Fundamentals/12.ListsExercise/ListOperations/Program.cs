using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOperations
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
                switch (commands[0])
                {
                    case "ADD":
                        numbers.Add(int.Parse(commands[1]));
                        break;
                    case "INSERT":

                        if (isValidIndex(int.Parse(commands[2]), numbers.Count))
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else
                        {
                            numbers.Insert(int.Parse(commands[2]), int.Parse(commands[1]));
                        }

                        break;
                    case "REMOVE":
                        if (isValidIndex(int.Parse(commands[1]), numbers.Count))
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else
                        {
                            numbers.RemoveAt(int.Parse(commands[1]));
                        }

                        break;

                    case "SHIFT":
                        if (commands[1] == "LEFT")
                        {
                            for (int i = 0; i < int.Parse(commands[2]); i++)
                            {
                                int firstNumber = numbers[0];
                                numbers.Remove(firstNumber);
                                numbers.Add(firstNumber);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < int.Parse(commands[2]); i++)
                            {
                                int lastNumber = numbers[numbers.Count - 1];
                                numbers.Remove(lastNumber);
                                numbers.Insert(0, lastNumber);
                            }
                        }

                        break;
                    default:
                        break;
                }
                commands = Console.ReadLine()
                .ToUpper()
                .Split()
                .ToArray();

            }
            Console.WriteLine(string.Join(' ', numbers));
        }

        static bool isValidIndex(int index, int count)
        {
            return index >= count || index < 0;
        }
    }
    }

