using System;

namespace PrintingTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                PrintingTriangle(1, i);
            }
            for (int i = n - 1; i >= 1; i--)
            {
                PrintingTriangle(1, i);
            }
        }

        static void PrintingTriangle(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

        }
    }
}
