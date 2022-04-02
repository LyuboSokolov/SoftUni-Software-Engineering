using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToList();



            string command = Console.ReadLine();
            
            Action<List<int>> print = x => Console.WriteLine(string.Join(" ", x));

            while (command != "end")
            {
                if (command == "print")
                {
                    print(numbers);
                }
                else
                {
                    Func<int, int> func = GetArithmeticFunc(command);
                    numbers = numbers.Select(func).ToList();
                }


                command = Console.ReadLine();
            }
        }
        static Func<int, int> GetArithmeticFunc(string command)
        {
            Func<int, int> func = num => num;

            if (command == "add")
            {
                func = num => num + 1;
            }
            else if (command == "subtract")
            {
                func = num => num - 1;
            }
            else if (command == "multiply")
            {
                func = num => num * 2;
            }

            return func;
        }
    }
}
