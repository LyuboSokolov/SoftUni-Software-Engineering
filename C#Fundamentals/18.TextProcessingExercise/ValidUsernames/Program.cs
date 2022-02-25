using System;
using System.Collections.Generic;
using System.Linq;

namespace ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                 .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                 .ToList();


            for (int i = 0; i < input.Count; i++)
            {
                string currentWord = input[i];

                for (int j = 0; j < currentWord.Length; j++)
                {
                    char symbol = currentWord[j];

                    if (((symbol >= 47 && symbol <= 57) ||
                        (symbol >= 65 && symbol <= 90) ||
                        (symbol >= 97 && symbol <= 122) ||
                        symbol == 95 ||
                        symbol == 45) == false)
                    {
                        input.RemoveAt(i);
                        i--;
                        break;
                    }
                    else if (currentWord.Length < 3 || currentWord.Length > 16)
                    {
                        input.RemoveAt(i);
                        i--;
                        break;
                    }
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, input));
        }
    }
}
