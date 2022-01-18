using System;

namespace Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double sum = double.Parse(Console.ReadLine());
            int counter = 0;

            while (sum > 0)
            {
                if (sum >= 2)
                {
                    sum %= 2.0;
                    counter++;
                }
                else if (sum >= 1)
                {
                    sum %= 1.0;
                    counter++;
                }
                else if (sum >= 0.50)
                {
                    sum %= 0.50;
                    counter++;
                }
                else if (sum >= 0.20)
                {
                    sum %= 0.20;
                    counter++;
                }
                else if (sum >= 0.10)
                {
                    sum %= 0.10;
                    counter++;
                }
                else if (sum >= 0.05)
                {
                    sum %= 0.05;
                    counter++;
                }
                else if (sum >= 0.02)
                {
                    sum %= 0.02;
                    counter++;
                }
                else if (sum > 0)
                {
                    sum = Math.Round(sum, 2);
                    sum %= 0.01;
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
