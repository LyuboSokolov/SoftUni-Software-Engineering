using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int score = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<string, int, bool> func = (name, score) =>
              {
                  int sum = 0;
                  foreach (var ch in name)
                  {
                      sum += ch;
                  }
                  return sum >= score;
              };
           
            Console.WriteLine(string.Join(" ",names.Find(x => func(x,score))));
        }
    }
}
