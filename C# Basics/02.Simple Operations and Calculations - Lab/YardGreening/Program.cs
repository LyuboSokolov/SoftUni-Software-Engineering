﻿using System;

namespace YardGreening
{
    class Program
    {
        static void Main(string[] args)
        {
            double metric = double.Parse(Console.ReadLine());
            double price = metric * 7.61;
            double discount = price * 0.18;
            double finalPrice = price - discount;

            Console.WriteLine($"The final price is: {finalPrice:f2} lv.");
            Console.WriteLine($"The discount is: {discount:f2} lv.");
        }
    }
}
