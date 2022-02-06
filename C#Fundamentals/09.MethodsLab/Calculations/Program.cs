using System;

namespace Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string operation = Console.ReadLine();
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            if (operation == "add")
            {
                ADDNumbers(firstNumber, secondNumber);
            }
            else if (operation == "multiply")
            {
                MultiplyNumbers(firstNumber, secondNumber);
            }
            else if (operation == "subtract")
            {
                SubtracktNumbers(firstNumber, secondNumber);
            }
            else if (operation == "divide")
            {
                DivideNumbers(firstNumber, secondNumber);
            }
        }

        static void DivideNumbers(int firstNumber, int secondNumber)
        {
            if (secondNumber != 0)
            {
                Console.WriteLine(firstNumber / secondNumber);
            }

        }
        static void SubtracktNumbers(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber - secondNumber);
        }

        static void MultiplyNumbers(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber * secondNumber);
        }

        static void ADDNumbers(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber + secondNumber);
        }
    }
}

