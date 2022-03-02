using System;
using System.Linq;

namespace HeartDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbersOfHeartsOfEachHouse = Console.ReadLine()
                .Split('@', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int currentPosition = 0;
            bool isFailed = false;
            int count = 0;

            while (command[0]?.ToUpper() != "LOVE!")
            {
                int index = int.Parse(command[1]);
                currentPosition += index;


                if (currentPosition >= numbersOfHeartsOfEachHouse.Length)
                {
                    currentPosition = 0;
                }

                if (numbersOfHeartsOfEachHouse[currentPosition] - 2 == 0)
                {
                    numbersOfHeartsOfEachHouse[currentPosition] = 0;
                    Console.WriteLine($"Place {currentPosition} has Valentine's day.");
                }
                else if (numbersOfHeartsOfEachHouse[currentPosition] - 2 < 0)
                {
                    Console.WriteLine($"Place {currentPosition} already had Valentine's day.");
                }
                else
                {
                    numbersOfHeartsOfEachHouse[currentPosition] -= 2;
                }

                command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"Cupid's last position was {currentPosition}.");



            for (int i = 0; i < numbersOfHeartsOfEachHouse.Length; i++)
            {
                if (numbersOfHeartsOfEachHouse[i] > 0)
                {
                    isFailed = true;
                    count++;
                }
            }

            if (isFailed)
            {
                Console.WriteLine($"Cupid has failed {count} places.");
            }
            else
            {
                Console.WriteLine($"Mission was successful.");
            }
        }
    }
}
