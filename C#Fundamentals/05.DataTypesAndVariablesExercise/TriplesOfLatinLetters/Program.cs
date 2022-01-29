using System;

namespace TriplesOfLatinLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 97; i < 97 + n; i++)
            {
                for (int k = 97; k < 97 + n; k++)
                {
                    for (int l = 97; l < 97 + n; l++)
                    {
                        Console.WriteLine($"{(char)i}{(char)k}{(char)l}");
                    }
                }
            }
        }
    }
}
