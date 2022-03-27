using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nAndM = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = nAndM[0];
            int m = nAndM[1];

            HashSet<int> firstNumbers = new HashSet<int>();
            HashSet<int> secondNumbers = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                firstNumbers.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < m; i++)
            {
                secondNumbers.Add(int.Parse(Console.ReadLine()));
            }

            firstNumbers.IntersectWith(secondNumbers);
            Console.WriteLine(string.Join(" ",firstNumbers));
        }
    }
}
