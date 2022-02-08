using System;

namespace SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            GetMinNumber();
        }

        static void GetMinNumber()
        {
            int smallestNumber = int.MaxValue;
            for (int i = 0; i < 3; i++)
            {
                int firstNumber = int.Parse(Console.ReadLine());
                if (firstNumber < smallestNumber)
                {
                    smallestNumber = firstNumber;
                }

            }
            Console.WriteLine(smallestNumber);

        }
    }
}
