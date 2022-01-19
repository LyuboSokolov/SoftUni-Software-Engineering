using System;

namespace SushiTime
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeSushi = Console.ReadLine();
            string nameRestorant = Console.ReadLine();
            int porciq = int.Parse(Console.ReadLine());
            string porachka = Console.ReadLine();
            double price = 0;
            double totalPrice = 0;

            if (nameRestorant == "Sushi Zone")
            {
                if (typeSushi == "sashimi")
                {
                    price += 4.99;
                }
                else if (typeSushi == "maki")
                {
                    price += 5.29;
                }
                else if (typeSushi == "uramaki")
                {
                    price += 5.99;
                }
                else if (typeSushi == "temaki")
                {
                    price += 4.29;
                }

            }

            else if (nameRestorant == "Sushi Time")
            {
                if (typeSushi == "sashimi")
                {
                    price += 5.49;
                }
                else if (typeSushi == "maki")
                {
                    price += 4.69;
                }
                else if (typeSushi == "uramaki")
                {
                    price += 4.49;
                }
                else if (typeSushi == "temaki")
                {
                    price += 5.19;
                }
            }
            else if (nameRestorant == "Sushi Bar")
            {
                if (typeSushi == "sashimi")
                {
                    price += 5.25;
                }
                else if (typeSushi == "maki")
                {
                    price += 5.55;
                }
                else if (typeSushi == "uramaki")
                {
                    price += 6.25;
                }
                else if (typeSushi == "temaki")
                {
                    price += 4.75;
                }
            }
            else if (nameRestorant == "Asian Pub")
            {
                if (typeSushi == "sashimi")
                {
                    price += 4.50;
                }
                else if (typeSushi == "maki")
                {
                    price += 4.80;
                }
                else if (typeSushi == "uramaki")
                {
                    price += 5.50;
                }
                else if (typeSushi == "temaki")
                {
                    price += 5.50;
                }
            }
            else
            {
                Console.WriteLine($"{nameRestorant} is invalid restaurant!");
            }
            if (nameRestorant == "Sushi Zone" || nameRestorant == "Sushi Time" ||
                 nameRestorant == "Sushi Bar" || nameRestorant == "Asian Pub")
            {
                if (porachka == "Y")
                {
                    totalPrice = porciq * price * 1.20;
                    Console.WriteLine($"Total price: {Math.Ceiling(totalPrice)} lv.");
                }
                else
                {
                    totalPrice = porciq * price;
                    Console.WriteLine($"Total price: {Math.Ceiling(totalPrice)} lv.");
                }
            }
            
        }
    }
}
