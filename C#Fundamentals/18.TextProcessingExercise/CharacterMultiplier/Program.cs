using System;

namespace CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            double sum = CharacterSum(input[0], input[1]);

            Console.WriteLine(sum);
        }

        private static double CharacterSum(string word1, string word2)
        {

            double multiplied = 0;
            for (int i = 0; i < Math.Max(word1.Length, word2.Length); i++)
            {
                double currentMultiplied = 0;

                if (word1.Length > i && word2.Length > i)
                {
                    currentMultiplied = word1[i] * word2[i];
                }
                else if (word1.Length > i)
                {
                    currentMultiplied = word1[i];
                }
                else if (word2.Length > i)
                {
                    currentMultiplied = word2[i];
                }


                multiplied += currentMultiplied;
            }
            return multiplied;
        }
    }
}
