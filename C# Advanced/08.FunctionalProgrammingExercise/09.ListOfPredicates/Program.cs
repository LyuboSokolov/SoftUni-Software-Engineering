using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] sequnceNumbers = Console.ReadLine()
                                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                          .Select(int.Parse)
                                          .ToArray();

            Func<int, int[], bool> func = (number, devideNumber) =>
              {
                  bool isDevideByAllNumbers = true;
                  foreach (var currDevideNumber in devideNumber)
                  {
                      if (number % currDevideNumber != 0)
                      {
                          isDevideByAllNumbers = false;
                          break;
                      }

                  }
                  return isDevideByAllNumbers;
              };
            List<int> result = Enumerable.Range(1, n).Where(x => func(x, sequnceNumbers)).ToList();
            Console.WriteLine(string.Join(" ", result));

            //for (int i = 1; i <= n; i++)
            //{
            //    if (func(i, sequnceNumbers))
            //    {
            //        result.Add(i);
            //    }
            //}
            //Console.WriteLine(string.Join(" ", result));
        }
    }
}
