using System;

namespace FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());

            double firstNumberFactorial = GetFirstNumberFactorial(firstNumber);
            double secondNumberFactorial = GetSecondNumberFactorial(secondNumber);

            FactorialDivision(firstNumberFactorial, secondNumberFactorial);

        }

        static void FactorialDivision(double firstNumberFactorial, double secondNumberFactorial)
        {
            double division = 0;

            division = firstNumberFactorial / secondNumberFactorial;

            Console.WriteLine($"{division:f2}");
        }

        static double GetSecondNumberFactorial(double secondNumber)
        {
            double factorial = 1;
            for (int i = 1; i <= secondNumber; i++)
            {
                factorial *= i;
            }
            return factorial;
        }

        static double GetFirstNumberFactorial(double firstNumber)
        {
            double factorial = 1;
            for (int i = 1; i <= firstNumber; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}
