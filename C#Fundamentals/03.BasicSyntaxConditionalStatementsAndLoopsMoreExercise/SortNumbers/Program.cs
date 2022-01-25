using System;

namespace SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int smallest = int.MaxValue;
            int mid = 0;
            int biggest = int.MinValue;
            int firstNumber = 0;
            int secondNumber = 0;
            int thirdNumber = 0;


            for (int i = 0; i < 3; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (i == 0)
                {
                    firstNumber = number;
                }
                else if (i == 1)
                {
                    secondNumber = number;
                }
                else if (i == 2)
                {
                    thirdNumber = number;
                }


                if (smallest > number)
                {
                    smallest = number;
                }
                if (biggest < number)
                {
                    biggest = number;
                }

            }
            if (firstNumber > smallest && firstNumber < biggest)
            {
                mid = firstNumber;
            }
            else if (secondNumber > smallest && secondNumber < biggest)
            {
                mid = secondNumber;
            }
            else if (thirdNumber > smallest && thirdNumber < biggest)
            {
                mid = thirdNumber;
            }
            else if (firstNumber == secondNumber)
            {
                mid = firstNumber;
            }
            else if (firstNumber == thirdNumber)
            {
                mid = firstNumber;
            }

            else if (secondNumber == thirdNumber)
            {
                mid = secondNumber;
            }

            Console.WriteLine(biggest);
            Console.WriteLine(mid);
            Console.WriteLine(smallest);
        }
    }
}
