using System;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            double budjet = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double price = 0;

            if (budjet<=100)
            {
                if (season=="summer")
                {
                    price = budjet * 0.30;
                    Console.WriteLine("Somewhere in Bulgaria");
                    Console.WriteLine($"Camp - {price:f2}");
                }
                else if (season =="winter")
                {
                    price = budjet * 0.70;
                    Console.WriteLine("Somewhere in Bulgaria");
                    Console.WriteLine($"Hotel - {price:f2}");
                }
                
            }
            else if (budjet<=1000)
            {
                if (season == "summer")
                {
                    price = budjet * 0.40;
                    Console.WriteLine("Somewhere in Balkans");
                    Console.WriteLine($"Camp - {price:f2}");

                }
                else if (season == "winter")
                {
                    price = budjet * 0.80;
                    Console.WriteLine("Somewhere in Balkans");
                    Console.WriteLine($"Hotel - {price:f2}");
                }
                
            }
            else
            {
                price = budjet * 0.90;
                Console.WriteLine("Somewhere in Europe");
                Console.WriteLine($"Hotel - {price:f2}");
            }
            

        }
    }
}
