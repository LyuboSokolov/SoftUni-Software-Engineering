using System;

namespace CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstSymbol = char.Parse(Console.ReadLine());
            char secondSymbol = char.Parse(Console.ReadLine());

            PrintAllChar(firstSymbol, secondSymbol);
        }

        static void PrintAllChar(char firstSymbol, char secondSymbol)
        {
            if (firstSymbol < secondSymbol)
            {
                for (int i = firstSymbol + 1; i < secondSymbol; i++)
                {
                    Console.Write($"{(char)i} ");
                }
            }
            else
            {
                for (int i = secondSymbol + 1; i < firstSymbol; i++)
                {
                    Console.Write($"{(char)i} ");
                }
            }
        }
    }
}
