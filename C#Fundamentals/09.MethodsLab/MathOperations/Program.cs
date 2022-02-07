using System;

namespace MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal result = MathOperations();
            Console.WriteLine($"{result}");
        }

        static decimal MathOperations()
        {
            decimal numberFirst = decimal.Parse(Console.ReadLine());
            char symbol = char.Parse(Console.ReadLine());
            decimal numberSecond = decimal.Parse(Console.ReadLine());
            decimal result = 0;

            if (symbol == '/' && numberSecond != 0)
            {
                result = numberFirst / numberSecond;
            }
            else if (symbol == '*')
            {
                result = numberFirst * numberSecond;
            }
            else if (symbol == '+')
            {
                result = numberFirst + numberSecond;
            }
            else if (symbol == '-')
            {
                result = numberFirst - numberSecond;
            }
            return result;
        }
    }
}

