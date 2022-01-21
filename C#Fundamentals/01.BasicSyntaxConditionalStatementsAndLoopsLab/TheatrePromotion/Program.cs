using System;

namespace TheatrePromotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine().ToLower();
            int age = int.Parse(Console.ReadLine());
            int sum = 0;

            if (day == "weekday")
            {
                if ((0 <= age && age <= 18) || (age > 64 && age <= 122))
                {
                    sum = 12;
                }
                else if (18 < age && age <= 64)
                {
                    sum = 18;
                }
                else
                {
                    Console.WriteLine("Error!");
                }

            }
            else if (day == "weekend")
            {
                if ((0 <= age && age <= 18) || (age > 64 && age <= 122))
                {
                    sum = 15;
                }
                else if (18 < age && age <= 64)
                {
                    sum = 20;
                }
                else
                {
                    Console.WriteLine("Error!");
                }
            }
            else if (day == "holiday")
            {
                if (0 <= age && age <= 18)
                {
                    sum = 5;
                }
                else if (18 < age && age <= 64)
                {
                    sum = 12;
                }
                else if (age > 64 && age <= 122)
                {
                    sum = 10;
                }
                else
                {
                    Console.WriteLine("Error!");
                }
            }

            if (sum != 0)
            {
                Console.WriteLine($"{sum}$");
            }
        }
    }
}

