using System;

namespace CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double priceLaundry = double.Parse(Console.ReadLine());
            int priceToy = int.Parse(Console.ReadLine());
            int sumMoney = 0;
            int allToys = 0;
            double priceAllToys = 0;
            double allMoney = 0;
            int count = 1;
            double allSaveMoney = 0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    sumMoney = 10 * count;
                    allSaveMoney += sumMoney;

                    allSaveMoney -= 1;
                    count++;
                }
                else
                {
                    allToys += 1;

                }
            }
            priceAllToys = allToys * priceToy;
            allMoney = priceAllToys + allSaveMoney;
            if (allMoney >= priceLaundry)
            {
                Console.WriteLine($"Yes! {allMoney - priceLaundry:f2}");
            }
            else
            {
                Console.WriteLine($"No! {priceLaundry - allMoney:f2}");
            }
        }
    }
}
