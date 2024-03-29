﻿using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string typeGrop = Console.ReadLine();
            string day = Console.ReadLine();

            double price = 0;

            if (typeGrop == "Students")
            {
                if (day == "Friday")
                {
                    price = people * 8.45;
                }
                else if (day == "Saturday")
                {
                    price = people * 9.80;
                }
                else if (day == "Sunday")
                {
                    price = people * 10.46;
                }
                if (people >= 30)
                {
                    price *= 0.85;
                }
            }
            else if (typeGrop == "Business")
            {
                if (people >= 100)
                {
                    people -= 10;
                }
                if (day == "Friday")
                {
                    price = people * 10.90;
                }
                else if (day == "Saturday")
                {
                    price = people * 15.60;
                }
                else if (day == "Sunday")
                {
                    price = people * 16;
                }

            }
            else if (typeGrop == "Regular")
            {
                if (day == "Friday")
                {
                    price = people * 15;
                }
                else if (day == "Saturday")
                {
                    price = people * 20;
                }
                else if (day == "Sunday")
                {
                    price = people * 22.50;
                }

                if (people >= 10 && people <= 20)
                {
                    price *= 0.95;
                }

            }

            Console.WriteLine($"Total price: {price:f2}");
        }
    }
}
