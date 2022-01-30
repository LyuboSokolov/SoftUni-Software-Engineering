using System;

namespace BalancedBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int openingBracket = 0;
            int closingBracket = 0;
            bool isClosingBracket = false;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if (input == "(")
                {
                    openingBracket++;
                    isClosingBracket = true;
                }
                else if (input == ")" && isClosingBracket)
                {
                    closingBracket++;
                    isClosingBracket = false;
                }
            }

            if (openingBracket == closingBracket)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
