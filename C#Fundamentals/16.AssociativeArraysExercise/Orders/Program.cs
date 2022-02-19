using System;
using System.Collections.Generic;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> products = new Dictionary<string, List<double>>();

            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "buy")
            {
                string productName = input[0];
                double price = double.Parse(input[1]);
                double quantity = double.Parse(input[2]);

                if (products.ContainsKey(productName) == false)
                {
                    products.Add(productName, new List<double>());
                    products[productName].Add(price);
                    products[productName].Add(quantity);
                }
                else
                {
                    products[productName][0] = price;
                    products[productName][1] += quantity;
                }

                input = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Key} -> { product.Value[0] * product.Value[1]:F2}");
            }
        }
    }
}
