using System;

namespace SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int countDays = 0;
            int leavingSpiceDay = 0;
            int totalAmountSpice = 0;

            while (startingYield >= 100)
            {
                countDays++;
                if (totalAmountSpice < 26 && totalAmountSpice != 0)
                {
                    leavingSpiceDay = startingYield - 26;
                    totalAmountSpice = 0;
                    startingYield -= 10;
                }
                else
                {
                    leavingSpiceDay = startingYield - 26;
                    totalAmountSpice += leavingSpiceDay;
                    startingYield -= 10;
                }
            }

            if (totalAmountSpice >= 26)
            {
                totalAmountSpice -= 26;
            }
            else
            {
                totalAmountSpice = 0;
            }
            Console.WriteLine(countDays);
            Console.WriteLine(totalAmountSpice);
        }
    }
}
