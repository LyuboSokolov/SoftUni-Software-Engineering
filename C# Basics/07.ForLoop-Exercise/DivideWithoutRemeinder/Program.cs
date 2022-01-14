using System;

namespace DivideWithoutRemeinder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double allNum = 0;

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());

                if (input % 2 == 0)
                {
                    p1 += 1;
                }
                if (input % 3 == 0)
                {
                    p2 += 1;
                }
                if (input % 4 == 0)
                {
                    p3 += 1;
                }
            }
            allNum = p1 + p2 + p3;
            Console.WriteLine($"{ p1 / n * 100:f2}%");
            Console.WriteLine($"{ p2 / n * 100:f2}%");
            Console.WriteLine($"{ p3 / n * 100:f2}%");
        }
    }
}
