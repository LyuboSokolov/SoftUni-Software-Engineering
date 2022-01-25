using System;

namespace RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGamesCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displeyPrice = double.Parse(Console.ReadLine());

            int brokenHeadset = 0;
            int brokenMouse = 0;
            int brokenKeyboard = 0;
            int brokenDispley = 0;
            double totalSum = 0;

            if (lostGamesCount >= 2)
            {
                brokenHeadset = lostGamesCount / 2;
            }
            if (lostGamesCount >= 3)
            {
                brokenMouse = lostGamesCount / 3;
            }
            if (lostGamesCount >= 6)
            {
                brokenKeyboard = lostGamesCount / 6;
                if (brokenKeyboard >= 2)
                {
                    brokenDispley = brokenKeyboard / 2;
                }
            }

            totalSum = headsetPrice * brokenHeadset + mousePrice * brokenMouse + keyboardPrice * brokenKeyboard + displeyPrice * brokenDispley;

            Console.WriteLine($"Rage expenses: {totalSum:f2} lv.");
        }
    }
}
