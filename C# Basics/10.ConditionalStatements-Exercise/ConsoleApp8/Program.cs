using System;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();
            double holidays = double.Parse(Console.ReadLine());
            int pscWeekends = int.Parse(Console.ReadLine());
            double weekendsSofia = 0;
            double playSofia = 0;
            double playSofiaHome = 0;
            double playHolidays = 0;
            double allGame = 0;

            weekendsSofia = 48.00 - pscWeekends;
            playSofia = weekendsSofia * 3 / 4;
            playSofiaHome = playSofia + pscWeekends;
            playHolidays = holidays * 2 / 3;
            allGame = playSofiaHome + playHolidays;
           
            if (year=="leap")
            {
                allGame = allGame * 1.15;
                Console.WriteLine(Math.Floor(allGame));
            }
            else
            {
                Console.WriteLine(Math.Floor(allGame));
            }


        }
    }
}
