using System;

namespace GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double currentBalance = double.Parse(Console.ReadLine());
            double allBalance = currentBalance;
            double productPirice = 0;

            string input = Console.ReadLine();

            while (input != "Game Time")
            {
                if (input == "OutFall 4")
                {
                    productPirice = 39.99;
                }
                else if (input == "CS: OG")
                {
                    productPirice = 15.99;
                }
                else if (input == "Zplinter Zell")
                {
                    productPirice = 19.99;
                }
                else if (input == "Honored 2")
                {
                    productPirice = 59.99;
                }
                else if (input == "RoverWatch")
                {
                    productPirice = 29.99;
                }
                else if (input == "RoverWatch Origins Edition")
                {
                    productPirice = 39.99;
                }
                else
                {
                    Console.WriteLine("Not Found");
                    input = Console.ReadLine();
                    continue;
                }
                currentBalance -= productPirice;
                if (currentBalance >= 0)
                {
                    Console.WriteLine($"Bought {input}");
                }
                else
                {
                    Console.WriteLine("Too Expensive");
                    currentBalance += productPirice;
                }
                if (currentBalance == 0)
                {
                    Console.WriteLine("Out of money!");

                }
                input = Console.ReadLine();
            }
            if (currentBalance > 0)
            {
                Console.WriteLine($"Total spent: ${allBalance - currentBalance:f2}. Remaining: ${currentBalance:f2}");
            }
        }
    }
}
