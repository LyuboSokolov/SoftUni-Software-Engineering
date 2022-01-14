using System;

namespace Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double p4 = 0;
            double p5 = 0;

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                if (input < 200)
                {
                    p1 += 1;
                }
                else if (input >= 200 && input <= 399)
                {
                    p2 += 1;
                }
                else if (input >= 400 && input <= 599)
                {
                    p3 += 1;
                }
                else if (input >= 600 && input <= 799)
                {
                    p4 += 1;
                }
                else
                {
                    p5 += 1;
                }

            }
            Console.WriteLine($"{p1 / n * 100:f2}%");
            Console.WriteLine($"{p2 / n * 100:f2}%");
            Console.WriteLine($"{p3 / n * 100:f2}%");
            Console.WriteLine($"{p4 / n * 100:f2}%");
            Console.WriteLine($"{p5 / n * 100:f2}%");
        }
    }
}
