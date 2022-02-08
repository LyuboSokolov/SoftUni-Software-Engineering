using System;

namespace PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();

            bool character = IsChar(input);
            bool digitsAndLetters = IsOnlyDigits(input);
            bool leastTwoDaigits = IsHaveTwoDigis(input);

            if (character && digitsAndLetters && leastTwoDaigits)
            {
                Console.WriteLine("Password is valid");
            }
            if (!character)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (!digitsAndLetters)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (!leastTwoDaigits)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
        }

        static bool IsHaveTwoDigis(string input)
        {
            int digitsCount = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char symbol = input[i];
                if (symbol >= '0' && symbol <= '9')
                {
                    digitsCount++;
                }
            }
            if (digitsCount >= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool IsOnlyDigits(string input)
        {
            bool isValid = false;
            for (int i = 0; i < input.Length; i++)
            {
                char symbols = input[i];
                if ((symbols >= 'a' && symbols <= 'z') || ((int)symbols >= 48 && (int)symbols <= 57))
                {
                    isValid = true;

                }
                else
                {
                    isValid = false;
                    break;
                }

            }
            if (isValid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool IsChar(string input)
        {
            if (input.Length >= 6 && input.Length <= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

