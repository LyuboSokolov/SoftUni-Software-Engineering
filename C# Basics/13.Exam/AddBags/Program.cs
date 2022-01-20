using System;

namespace AddBags
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceBagsMore20 = double.Parse(Console.ReadLine());
            double kgBags = double.Parse(Console.ReadLine());
            int daysToTravelling = int.Parse(Console.ReadLine());
            int pscBaggage = int.Parse(Console.ReadLine());
            double sum = 0;
            double totalSum = 0;

            if (kgBags < 10)
            {
                sum = priceBagsMore20 * 0.20;

            }
            else if (kgBags <= 20)
            {
                sum = priceBagsMore20 * 0.50;
            }
            else if (kgBags > 20)
            {
                sum = priceBagsMore20;
            }
            if (daysToTravelling>30)
            {
                sum *= 1.10;
            }
            else if (daysToTravelling>=7 && daysToTravelling<=30)
            {
                sum *= 1.15;
            }
            else if (daysToTravelling<7)
            {
                sum *= 1.40;
            }
            totalSum = sum * pscBaggage;

            Console.WriteLine($"The total price of bags is: {totalSum:F2} lv.");
        }
    }
}
