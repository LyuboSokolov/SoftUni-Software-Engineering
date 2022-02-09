using System;

namespace AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int sum = GetSum(firstNumber, secondNumber);
            Console.WriteLine(GetSubtract(sum, thirdNumber)); ;
        }

        static int GetSubtract(int sum, int thirdNumber)
        {
            return sum - thirdNumber;
        }

        static int GetSum(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }
    }
}

