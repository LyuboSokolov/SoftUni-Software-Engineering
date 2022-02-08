using System;

namespace VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintNumbersOfVowels();
        }

        static void PrintNumbersOfVowels()
        {
            string input = Console.ReadLine();
            char vowel = '\n';
            int count = 0;

            for (int i = 0; i < input.Length; i++)
            {
                vowel = input[i];
                switch (vowel)
                {
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'y':
                    case 'o':
                    case 'u':
                    case 'A':
                    case 'E':
                    case 'I':
                    case 'Y':
                    case 'O':
                    case 'U':
                        count++;
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(count);
        }
    }
}
