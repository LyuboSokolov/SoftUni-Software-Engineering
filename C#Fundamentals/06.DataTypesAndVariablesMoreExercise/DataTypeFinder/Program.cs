﻿using System;

namespace DataTypeFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                bool isBool = bool.TryParse(input, out bool resultsBool);
                bool isInt = int.TryParse(input, out int resultsInt);
                bool isDouble = double.TryParse(input, out double resultsDouble);
                bool isChar = char.TryParse(input, out char resultsChar);

                if (isBool)
                {
                    Console.WriteLine($"{input} is boolean type");
                }
                else if (isInt)
                {
                    Console.WriteLine($"{input} is integer type");
                }
                else if (isDouble)
                {
                    Console.WriteLine($"{input} is floating point type");
                }
                else if (isChar)
                {
                    Console.WriteLine($"{input} is character type");
                }
                else
                {
                    Console.WriteLine($"{input} is string type");
                }
                input = Console.ReadLine();
            }
        }
    }
}
