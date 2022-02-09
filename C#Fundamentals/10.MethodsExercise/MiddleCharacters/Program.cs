using System;

namespace MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            PrintMiddleChar(input);
        }
        static void PrintMiddleChar(string input)
        {
            string middleSymbols = string.Empty;
            if (input.Length % 2 == 0)
            {
                char firstMiddleSymbol = input[(input.Length - 1) / 2];
                char secondMiddleSymbol = input[input.Length / 2];
                middleSymbols += firstMiddleSymbol;
                middleSymbols += secondMiddleSymbol;
            }
            else
            {
                middleSymbols = input[(input.Length / 2)].ToString();
            }
            Console.WriteLine(middleSymbols);
        }
    }
}
