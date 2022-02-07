using System;

namespace MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));
            int evenSum = GetSumOfEvenDigits(number);
            int oddSum = GetSumOfOddDigits(number);

            int result = GetMultipleOfEvenAndOdds(evenSum, oddSum);
            Console.WriteLine(result);
        }

        private static int GetMultipleOfEvenAndOdds(int evenSum, int oddSum)
        {
            return evenSum * oddSum;
        }

        static int GetSumOfOddDigits(int number)
        {
            int digits = 0;
            int sum = 0;
            while (number > 0)
            {
                digits = number % 10;
                number /= 10;
                if (digits % 2 == 1)
                {
                    sum += digits;
                }
            }
            return sum;
        }

        static int GetSumOfEvenDigits(int number)
        {
            int digits = 0;
            int sum = 0;
            while (number > 0)
            {
                digits = number % 10;
                number /= 10;
                if (digits % 2 == 0)
                {
                    sum += digits;
                }
            }
            return sum;
        }
    }
}

