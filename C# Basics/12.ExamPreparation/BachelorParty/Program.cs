using System;

namespace BachelorParty
{
    class Program
    {
        static void Main(string[] args)
        {
            double paymentForIzpalnitel = double.Parse(Console.ReadLine());
            double input = 0;
            double priceForGroup = 0;
            double priceForAll = 0;
            double ostatak = 0;
            double allGuest = 0;
            string command = string.Empty;
            
            while (command != "The restaurant is full")
            {
                command = Console.ReadLine();
                if (command == "The restaurant is full")
                {
                    break;
                }
                input = double.Parse(command);
                if (input < 5)
                {
                    priceForGroup = input * 100;
                }
                else 
                {
                    priceForGroup = input * 70;
                }
                priceForAll += priceForGroup;
                allGuest += input;

            }
            if (priceForAll > paymentForIzpalnitel)
            {
                ostatak = priceForAll - paymentForIzpalnitel;
                Console.WriteLine($"You have {allGuest} guests and {ostatak} leva left.");
            }
            else
            {
                Console.WriteLine($"You have {allGuest} guests and {priceForAll} leva income, but no singer.");
            }
        }
    }
}
