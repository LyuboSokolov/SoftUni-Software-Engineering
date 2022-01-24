using System;

namespace Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int div = 0;

            if (number % 2 == 0)
            {
                div = 2;
            }
            if (number % 3 == 0)
            {
                div = 3;
            }
            if (number % 6 == 0)
            {
                div = 6;
            }
            if (number % 7 == 0)
            {
                div = 7;
            }
            if (number % 10 == 0)
            {
                div = 10;
            }
            if (div == 0)
            {
                Console.WriteLine("Not divisible");
            }
            else
            {
                Console.WriteLine($"The number is divisible by {div}");
            }
        }
    }
}
