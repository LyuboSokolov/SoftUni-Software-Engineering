using System;
using System.Numerics;

namespace FromLeftToTheRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char symbol = '\n';
            string leftSide = string.Empty;
            string rightSide = string.Empty;
            bool isFinisNumber = false;
            BigInteger sumDigitsLeftSide = 0;
            BigInteger sumDigitsRightSide = 0;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                for (int j = 0; j < input.Length; j++)
                {
                    symbol = input[j];

                    if (symbol == ' ')
                    {
                        for (int k = j + 1; k < input.Length; k++)
                        {
                            symbol = input[k];
                            rightSide += symbol;
                            isFinisNumber = true;
                        }
                    }
                    if (isFinisNumber)
                    {
                        break;
                    }
                    leftSide += symbol;
                }

                BigInteger leftSideNumber = BigInteger.Parse(leftSide);
                BigInteger rigtSideNumber = BigInteger.Parse(rightSide);
                if (leftSideNumber > rigtSideNumber)
                {
                    leftSideNumber = BigInteger.Abs(leftSideNumber);
                    while (leftSideNumber > 0)
                    {
                        sumDigitsLeftSide += leftSideNumber % 10;
                        leftSideNumber /= 10;
                    }
                    Console.WriteLine(sumDigitsLeftSide);
                }
                else
                {
                    rigtSideNumber = BigInteger.Abs(rigtSideNumber);
                    while (rigtSideNumber > 0)
                    {
                        sumDigitsRightSide += rigtSideNumber % 10;
                        rigtSideNumber /= 10;
                    }
                    Console.WriteLine(sumDigitsRightSide);
                }

                symbol = '\n';
                isFinisNumber = false;
                leftSide = string.Empty;
                rightSide = string.Empty;
                sumDigitsLeftSide = 0;
                sumDigitsRightSide = 0;
            }
        }
    }
}
