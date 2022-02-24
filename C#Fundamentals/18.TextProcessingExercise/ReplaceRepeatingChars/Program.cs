using System;

namespace ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string result = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                char currentSymbol = input[i];

                if (i == 0)
                {
                    result += currentSymbol;
                }
                else if (currentSymbol != input[i - 1])
                {
                    result += currentSymbol;
                }
            }
            Console.WriteLine(result);
        }
    }
}
