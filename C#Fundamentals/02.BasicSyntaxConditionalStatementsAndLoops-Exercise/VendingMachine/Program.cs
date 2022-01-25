using System;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            double sumOfCoin = 0;
            double sumOfProducts = 0;
            bool invalidProduct = false;
            double price = 0;

            while (true)
            {
                input = Console.ReadLine();
                if (input == "Start")
                {
                    break;

                }
                double coin = double.Parse(input);
                if (coin == 0.1 || coin == 0.2 || coin == 0.5 || coin == 1 || coin == 2)
                {
                    sumOfCoin += coin;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coin}");
                }

            }

            while (input != "End")
            {
                input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                if (input == "Nuts")
                {
                    sumOfProducts += 2;
                    price = 2;

                }
                else if (input == "Water")
                {
                    sumOfProducts += 0.7;
                    price = 0.7;
                }
                else if (input == "Crisps")
                {
                    sumOfProducts += 1.5;
                    price = 1.5;
                }
                else if (input == "Soda")
                {
                    sumOfProducts += 0.8;
                    price = 0.8;
                }
                else if (input == "Coke")
                {
                    sumOfProducts += 1.0;
                    price = 1;
                }
                else
                {
                    Console.WriteLine("Invalid product");
                    invalidProduct = true;
                }

                if (sumOfProducts <= sumOfCoin && !invalidProduct)
                {
                    Console.WriteLine($"Purchased {input.ToLower()}");
                }
                if (sumOfProducts > sumOfCoin)
                {
                    Console.WriteLine("Sorry, not enough money");
                    sumOfProducts -= price;

                }
            }
            Console.WriteLine($"Change: {sumOfCoin - sumOfProducts:f2}");
        }
    }
}
