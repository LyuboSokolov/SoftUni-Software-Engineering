using System;

namespace SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                int sum = 0;
                int number = i;
                while (true)
                {
                    int digit = number % 10;
                    sum += digit;
                    number /= 10;
                    if (number == 0)
                    {
                        break;
                    }
                }
                bool isValid = (sum == 5 || sum == 7 || sum == 11);
                Console.WriteLine($"{i} -> {isValid}");
            }
        }
    }
}
