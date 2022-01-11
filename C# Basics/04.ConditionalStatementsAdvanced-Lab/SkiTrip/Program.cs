using System;

namespace SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string typeRoom = Console.ReadLine();
            string evaluation = Console.ReadLine();
            double price = 0;


            if (typeRoom == "room for one person")
            {
                price = 18 * (days - 1);
            }
            else if (typeRoom == "apartment")
            {
                if (days < 10)
                {
                    price = (25 * (days - 1)) * 0.7;
                }
                else if (days <= 15)
                {
                    price = (25 * (days - 1) * 0.65);
                }
                else if (days > 15)
                {
                    price = (25 * (days - 1) * 0.5);
                }
            }
            else if (typeRoom == "president apartment")
            {
                price = 35 * (days - 1);
                if (days < 10)
                {
                    price = price * 0.9;
                }
                else if (days <= 15)
                {
                    price = price * 0.85;
                }
                else
                {
                    price = price * 0.8;
                }
            }
            if (evaluation == "positive")
            {
                price = price + (price * 0.25);
            }
            else
            {
                price = price - (price * 0.1);
            }

            Console.WriteLine($"{price:f2}");

        }
    }
}
