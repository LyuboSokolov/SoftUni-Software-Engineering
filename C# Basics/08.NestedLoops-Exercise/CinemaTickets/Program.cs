using System;

namespace CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameMovie = string.Empty;
            double freeSeats = 0;
            int allSeats = 0;
            double totalTikets = 0;
            double totalStudends = 0;
            double totalStandard = 0;
            double totalKids = 0;

            nameMovie = Console.ReadLine();

            while (nameMovie != "Finish")
            {
                freeSeats = int.Parse(Console.ReadLine());
                allSeats = 0;
                int count1 = 0;
                int count2 = 0;
                int count3 = 0;

                for (int i = 0; i < freeSeats; i++)
                {
                    string input = Console.ReadLine();
                    if (input == "student")
                    {
                        count1++;
                        totalStudends++;
                    }
                    else if (input == "standard")
                    {
                        count2++;
                        totalStandard++;
                    }
                    else if (input == "kid")
                    {
                        count3++;
                        totalKids++;
                    }
                    else if (input == "End")
                    {
                        break;
                    }

                    allSeats = count1 + count2 + count3;
                }
                Console.WriteLine($"{nameMovie} - {allSeats / freeSeats * 100:f2}% full.");
                nameMovie = Console.ReadLine();
            }
            totalTikets = totalStandard + totalStudends + totalKids;
            Console.WriteLine($"Total tickets: {totalTikets}");
            Console.WriteLine($"{totalStudends / totalTikets * 100:f2}% student tickets.");
            Console.WriteLine($"{totalStandard / totalTikets * 100:f2}% standard tickets.");
            Console.WriteLine($"{totalKids / totalTikets * 100:f2}% kids tickets.");
        }
    }
}
