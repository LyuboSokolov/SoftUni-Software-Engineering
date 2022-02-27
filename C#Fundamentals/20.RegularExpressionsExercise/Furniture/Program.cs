using System;
using System.Text.RegularExpressions;

namespace Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>(?<furniture>[A-Za-z]+)<<(?<price>[0-9]+\.*[0-9]+)!(?<quantity>[0-9]+)";

            Regex regex = new Regex(pattern);
            string input = Console.ReadLine();
            double spendMoney = 0;

            Console.WriteLine("Bought furniture:");

            while (input != "Purchase")
            {
                Match match = regex.Match(input);

                if (match.Success)
                {
                    string name = match.Groups["furniture"].Value;
                    double price = double.Parse(match.Groups["price"].Value);
                    int quantity = int.Parse(match.Groups["quantity"].Value);
                    Console.WriteLine(name);
                    spendMoney += price * quantity;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Total money spend: {spendMoney:f2}");
        }
    }
}
