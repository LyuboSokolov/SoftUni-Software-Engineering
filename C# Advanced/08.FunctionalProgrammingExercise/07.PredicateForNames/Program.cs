using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .ToList();

            Func<List<string>, List<string>> filtredNames = name =>
             {
                 List<string> filtredName = new List<string>();
                 foreach (var currentName in name)
                 {
                     if (currentName.Length <= n)
                     {
                         filtredName.Add(currentName);
                     }
                 }
                 return filtredName;
             };
            Console.WriteLine(string.Join(Environment.NewLine, filtredNames(names)));
        }
    }
}
