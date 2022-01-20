using System;

namespace AirplaneSeats
{
    class Program
    {
        static void Main(string[] args)
        {
            int passengers = int.Parse(Console.ReadLine());
            string numberOfSeats = string.Empty;
            int countWindow = 0;
            int countMiddle = 0;
            int countAisle = 0;
            int allCount = 0;

            for (int i = 0; i < passengers; i++)
            {
                numberOfSeats = Console.ReadLine();
                char seats = numberOfSeats[1];
                if (seats == 'A')
                {
                    countWindow++;
                }
                else if (seats == 'F')
                {
                    countWindow++;
                }
                else if (seats == 'B')
                {
                    countAisle++;
                }
                else if (seats == 'E')
                {
                    countAisle++;
                }
                else if (seats == 'C')
                {
                    countMiddle++;
                }
                else if (seats == 'D')
                {
                    countMiddle++;
                }
                allCount = countMiddle + countAisle + countWindow;
            }

            Console.WriteLine($"Window Seats: {countWindow * 100.00 / allCount:F2}%");
            Console.WriteLine($"Middle Seats: {countAisle * 100.00 / allCount:F2}%");
            Console.WriteLine($"Aisle Seats: {countMiddle * 100.00 / allCount:F2}%");
        }
    }
}
