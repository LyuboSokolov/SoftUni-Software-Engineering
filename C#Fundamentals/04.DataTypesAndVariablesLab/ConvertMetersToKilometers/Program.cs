﻿using System;

namespace ConvertMetersToKilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            int meters = int.Parse(Console.ReadLine());
            decimal kilometers = 0;

            kilometers = meters / 1000M;
            Console.WriteLine($"{kilometers:f2}");
        }
    }
}
