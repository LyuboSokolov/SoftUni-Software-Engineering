﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int n = int.Parse(Console.ReadLine());

            Predicate<int> predicate = x => x % n != 0;

           numbers = numbers.Where(x=> predicate(x)).ToList();

            numbers.Reverse();

            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
