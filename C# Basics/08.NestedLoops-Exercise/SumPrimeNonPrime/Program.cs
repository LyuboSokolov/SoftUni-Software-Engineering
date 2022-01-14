using System;

namespace SumPrimeNonPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int number = 0;
            int sumOfPrime = 0;
            int sumOfNonPrime = 0;

            while (input != "stop")
            {
                number = int.Parse(input);
                if (number < 0)
                {
                    Console.WriteLine($"Number is negative.");
                    input = Console.ReadLine();
                    continue;
                }
                else if (number % 2 == 0 && number != 2)
                {
                    sumOfNonPrime += number;
                }
                else if (number % 3 == 0 && number != 3)
                {
                    sumOfNonPrime += number;
                }
                else if (number % 5 == 0 && number != 5)
                {
                    sumOfNonPrime += number;
                }
                else if (number % 7 == 0 && number != 7)
                {
                    sumOfNonPrime += number;
                }
                else
                {
                    sumOfPrime += number;
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"Sum of all prime numbers is: {sumOfPrime}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumOfNonPrime}");
        }
    }
}
