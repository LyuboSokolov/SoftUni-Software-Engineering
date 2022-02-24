using System;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string result = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                char forwardChar = (char)(currentChar + 3);
                result += forwardChar;

            }
            Console.WriteLine(result);
        }
    }
}
