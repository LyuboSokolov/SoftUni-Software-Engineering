using System;

namespace Holiday
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyForFood = double.Parse(Console.ReadLine());
            double moneyForSuvenirs = double.Parse(Console.ReadLine());
            double moneyForHotel = double.Parse(Console.ReadLine());

            double moneyForDiesel = (420 / 100.00) * 7 * 1.85;

            double moneyForAllFood = moneyForFood * 3;
            double moneyForAllSuvenirs = moneyForSuvenirs * 3;
            double moneyForAllDays = (moneyForHotel * 0.90) + (moneyForHotel * 0.85) + (moneyForHotel * 0.8);

            double MoneyTotal = moneyForAllFood + moneyForAllSuvenirs + moneyForAllDays +moneyForDiesel;
            Console.WriteLine($"Money needed: {MoneyTotal:f2}");


        }
    }
}
