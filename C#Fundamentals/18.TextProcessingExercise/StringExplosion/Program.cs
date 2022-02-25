using System;

namespace StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string result = string.Empty;

            int addStrength = 0;

            for (int i = 0; i < input.Length; i++)
            {

                if (input[i] == '>')
                {
                    if ((input[i + 1] >= 48 && input[i + 1] <= 57) == false)
                    {
                        continue;
                    }
                    int strength = (int.Parse(input[i + 1].ToString()));
                    strength += addStrength;
                    addStrength = 0;

                    for (int j = i + 1; j < i + 1 + strength; j++)
                    {
                        if (input[j] == '>')
                        {
                            addStrength++;

                            continue;
                        }
                        input = input.Remove(j, 1);
                        j--;
                        strength--;
                    }
                }
            }
            Console.WriteLine(input);
        }
    }
}
