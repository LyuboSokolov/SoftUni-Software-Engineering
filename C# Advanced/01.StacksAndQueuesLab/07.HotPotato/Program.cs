using System;
using System.Collections.Generic;

namespace _07.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());
            Queue<string> kids = new Queue<string>(input);
            int count = 0;

            while (kids.Count > 1)
            {
                count++;
               string kid = kids.Dequeue();

                if (count == n)
                {
                    Console.WriteLine($"Removed {kid}");
                    count = 0;
                }
                else
                {
                    kids.Enqueue(kid);
                }
                
            }
            Console.WriteLine($"Last is {kids.Dequeue()}");
        }
    }
}
