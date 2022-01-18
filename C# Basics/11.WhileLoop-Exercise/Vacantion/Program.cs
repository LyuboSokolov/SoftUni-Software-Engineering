using System;

namespace Vacantion
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyForHolidey = double.Parse(Console.ReadLine());
            double moneyOnHand = double.Parse(Console.ReadLine());
            string command = string.Empty;
            int counterAllDays = 0;
            int counterSpend = 0;
            double moneyOnDay = 0;

            while (counterSpend < 5 && moneyOnHand < moneyForHolidey)
            {
                command = Console.ReadLine();
                moneyOnDay = double.Parse(Console.ReadLine());
                counterAllDays++;
                if (command == "spend")
                {
                    counterSpend++;
                    if (moneyOnHand <= moneyOnDay)
                    {
                        moneyOnHand = 0;
                    }
                    else
                    {
                        moneyOnHand -= moneyOnDay;
                    }
                }
                if (command == "save")
                {
                    moneyOnHand += moneyOnDay;
                    counterSpend = 0;
                }
            }
            if (counterSpend >= 5)
            {
                Console.WriteLine($"You can't save the money.");
                Console.WriteLine($"{counterAllDays}");
            }
            if (moneyOnHand >= moneyForHolidey)
            {
                Console.WriteLine($"You saved the money for {counterAllDays} days.");
            }
        }
    }
}
