using System;

namespace StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int number = int.Parse(input);


            int sumOfAllNumber = 0;

            for (int i = 0; i < input.Length; i++)
            {
                string symbol = string.Empty;
                symbol += input[i];
                int sum = int.Parse(symbol);
                int total = 1;

                for (int j = 1; j <= sum; j++)
                {

                    total *= j;
                }

                sumOfAllNumber += total;

            }
            if (number == sumOfAllNumber)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
