using System;

namespace DigitsLettersAndOther
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string letter = string.Empty;
            string digits = string.Empty;
            string symbols = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                char currentSymbol = text[i];
                if ((currentSymbol >= 65 && currentSymbol <= 90) || (currentSymbol >= 97 && currentSymbol <= 122))
                {
                    letter += currentSymbol;
                }
                else if (currentSymbol >= 48 && currentSymbol <= 57)
                {
                    digits += currentSymbol;
                }
                else
                {
                    symbols += currentSymbol;
                }
            }

            Console.WriteLine(digits);
            Console.WriteLine(letter);
            Console.WriteLine(symbols);
        }
    }
}
