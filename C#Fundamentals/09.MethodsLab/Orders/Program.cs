using System;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            if (input == "coffee")
            {
                PrintCofee(quantity);
            }
            else if (input == "water")
            {
                PrintWater(quantity);
            }
            else if (input == "coke")
            {
                PrintCoke(quantity);
            }
            else if (input == "snacks")
            {
                PrintSnacks(quantity);
            }
        }

        static void PrintSnacks(int quantity)
        {
            decimal sum = 0;
            sum = quantity * (decimal)2.00;
            Console.WriteLine($"{sum:f2}");
        }

        static void PrintCoke(int quantity)
        {
            decimal sum = 0;
            sum = quantity * (decimal)1.40;
            Console.WriteLine($"{sum:f2}");
        }

        static void PrintWater(int quantity)
        {
            decimal sum = 0;
            sum = quantity * (decimal)1.00;
            Console.WriteLine($"{sum:f2}");
        }

        static void PrintCofee(int quantity)
        {
            decimal sum = 0;
            sum = quantity * (decimal)1.50;
            Console.WriteLine($"{sum:f2}");
        }
    }
}

