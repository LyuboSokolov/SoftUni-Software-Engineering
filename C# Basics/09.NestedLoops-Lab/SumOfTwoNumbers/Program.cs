using System;

namespace SumOfTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingNumber = int.Parse(Console.ReadLine());
            int finishNumber = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());
            int combinations = 0;
            bool isFound = false;

            for (int i = startingNumber; i <= finishNumber; i++)
            {
                for (int m = startingNumber; m <= finishNumber; m++)
                {
                    combinations++;
                    if (i + m == magicNumber)
                    {
                        Console.WriteLine($"Combination N:{combinations} ({i} + {m} = {magicNumber})");
                        isFound = true;
                        break;
                    }
                }
                if (isFound)
                {
                    break;
                }
            }
            if (!isFound)
            {
                Console.WriteLine($"{combinations} combinations - neither equals {magicNumber}");
            }
        }
    }
}
