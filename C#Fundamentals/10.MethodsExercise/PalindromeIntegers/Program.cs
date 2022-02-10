using System;

namespace PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string reverseInput = string.Empty;
                for (int i = input.Length - 1; i >= 0; i--)
                {
                    reverseInput += input[i];
                }
                if (input == reverseInput)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }
    }
}
