using System;

namespace TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            GetDivideDegitByEight(n);
        }

        static void GetDivideDegitByEight(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                int sum = 0;
                bool isValid = false;
                int currentNumber = i;
                while (currentNumber > 0)
                {
                    int currendDigit = currentNumber % 10;
                    sum += currendDigit;
                    if (currendDigit % 2 != 0)
                    {
                        isValid = true;
                    }
                    currentNumber /= 10;
                }
                if (isValid)
                {
                    if (sum % 8 == 0)
                    {
                        Console.WriteLine(i);
                    }
                }
            }
        }
    }
}