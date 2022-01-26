using System;

namespace RefactorSpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sumOfdigit = 0;
            int number = 0;
            bool isSpecialNumbers = false;
            for (int i = 1; i <= n; i++)
            {
                number = i;
                while (number > 0)
                {
                    sumOfdigit += number % 10;
                    number = number / 10;
                }
                isSpecialNumbers = (sumOfdigit == 5) || (sumOfdigit == 7) || (sumOfdigit == 11);
                Console.WriteLine($"{i} -> {isSpecialNumbers}");
                sumOfdigit = 0;
            }
        }
    }
}