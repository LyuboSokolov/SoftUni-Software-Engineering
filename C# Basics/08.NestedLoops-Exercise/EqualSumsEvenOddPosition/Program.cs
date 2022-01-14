using System;

namespace EqualSumsEvenOddPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            for (int i = firstNumber; i <= secondNumber; i++)
            {
                int firstDigit = i % 10;
                int secondDigit = (i / 10) % 10;
                int thirdDigit = (i / 100) % 10;
                int fourthDigit = (i / 1000) % 10;
                int fiveDigit = (i / 10000) % 10;
                int sixDigit = (i / 100000);

                if (firstDigit + thirdDigit + fiveDigit == secondDigit + fourthDigit + sixDigit)
                {
                    Console.Write(i + " ");
                }

            }
        }
    }
}
