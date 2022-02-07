using System;

namespace GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (input == "int")
            {
                int firstValue = int.Parse(Console.ReadLine());
                int secondValue = int.Parse(Console.ReadLine());
                GetMax(firstValue, secondValue);
                Console.WriteLine(GetMax(firstValue, secondValue));
            }
            else if (input == "char")
            {
                char firstValue = char.Parse(Console.ReadLine());
                char secondValue = char.Parse(Console.ReadLine());
                GetMax(firstValue, secondValue);
                Console.WriteLine(GetMax(firstValue, secondValue));
            }
            else if (input == "string")
            {
                string firstValue = Console.ReadLine();
                string secondValue = Console.ReadLine();
                GetMax(firstValue, secondValue);
                Console.WriteLine(GetMax(firstValue, secondValue));
            }
        }

        static int GetMax(int firstValue, int secondValue)
        {

            if (firstValue > secondValue)
            {
                return firstValue;
            }
            else
            {
                return secondValue;
            }
        }
        static char GetMax(char firstValue, char secondValue)
        {
            if (firstValue > secondValue)
            {
                return firstValue;
            }
            else
            {
                return secondValue;
            }
        }
        static string GetMax(string firstValue, string secondValue)
        {
            int sumFirstValue = 0;
            int sumSecondValue = 0;

            for (int i = 0; i < firstValue.Length; i++)
            {
                sumFirstValue += firstValue[i];
            }
            for (int j = 0; j < secondValue.Length; j++)
            {
                sumSecondValue += secondValue[j];
            }
            if (sumFirstValue > sumSecondValue)
            {
                return firstValue;
            }
            else
            {
                return secondValue;
            }
        }
    }
}
