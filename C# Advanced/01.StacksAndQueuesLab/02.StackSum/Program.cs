using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string input = Console.ReadLine().ToLower();
            Stack<int> allNumbers = new Stack<int>(numbers);

            while (input != "end")
            {
                string[] cmdArg = input.Split();
                if (input.Contains("add"))
                {
                    int firstNumber = int.Parse(cmdArg[1]);
                    int secondNumber = int.Parse(cmdArg[2]);
                    allNumbers.Push(firstNumber);
                    allNumbers.Push(secondNumber);
                }
                else if (input.Contains("remove"))
                {
                    int removeNumbers = int.Parse(cmdArg[1]);

                    if (removeNumbers <= allNumbers.Count)
                    {
                        for (int i = 0; i < removeNumbers; i++)
                        {
                            allNumbers.Pop();
                        }
                    }
                }
                input = Console.ReadLine().ToLower();
            }

            Console.WriteLine($"Sum: {allNumbers.Sum()}");
        }
    }
}
