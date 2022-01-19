using System;

namespace MultiplyTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            int a = input % 10;
            int b = (input % 100) / 10;
            int c = input / 100;

            for (int i = 1; i <= a; i++)
            {
                for (int j = 1; j <= b; j++)
                {
                    for (int k = 1; k <= c; k++)
                    {
                        int sum = i * j * k;
                        Console.WriteLine($"{i} * {j} * {k} = {sum};");
                    }
                }
            }
        }
    }
}
