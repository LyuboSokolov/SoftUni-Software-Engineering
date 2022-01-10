using System;

namespace ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceTrip = double.Parse(Console.ReadLine());
            int puzzle = int.Parse(Console.ReadLine());
            int kukli = int.Parse(Console.ReadLine());
            int beard = int.Parse(Console.ReadLine());
            int minion = int.Parse(Console.ReadLine());
            int truck = int.Parse(Console.ReadLine());
            double sum = 0;
            int pcsSum = 0;

            sum = puzzle * 2.60 + kukli * 3 + beard * 4.10 + minion * 8.20 + truck * 2;
            pcsSum = puzzle + kukli + beard + minion + truck;

            if (pcsSum >= 50)
            {
                sum = sum * 0.75;
            }

            sum = sum * 0.9;
            if (priceTrip <= sum)
            {
                Console.WriteLine($"Yes! {sum - priceTrip:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {priceTrip - sum:f2} lv needed.");
            }
        }
    }
}
