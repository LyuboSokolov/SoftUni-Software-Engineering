using System;

namespace PublicTransport
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            string season = Console.ReadLine();
            int time = 0;

            if (season == "Winter")
            {
                if (line == "208")
                {
                    time = 65;
                    time += 18;
                }
                else if (line == "15")
                {
                    time = 57;
                    time += 21;
                }
                else if (line == "240")
                {
                    time = 48;
                    time += 18;
                }
                else if (line == "Subway")
                {
                    time = 35;
                    time += 21;
                }
                Console.WriteLine($"Total travel time: {time} minutes");
            }
            else if (season == "Autumn")
            {
                if (line == "208")
                {
                    time = 45;
                    time += 18;
                }
                else if (line == "15")
                {
                    time = 42;
                    time += 21;
                }
                else if (line == "240")
                {
                    time = 37;
                    time += 18;
                }
                else if (line == "Subway")
                {
                    time = 35;
                    time += 21;
                }
                Console.WriteLine($"Total travel time: {time} minutes");
            }
            else if (season == "Spring")
            {
                if (line == "208")
                {
                    time = 39;
                    time += 18;
                }
                else if (line == "15")
                {
                    time = 36;
                    time += 21;
                }
                else if (line == "240")
                {
                    time = 31;
                    time += 18;
                }
                else if (line == "Subway")
                {
                    time = 35;
                    time += 21;
                }
                Console.WriteLine($"Total travel time: {time} minutes");
            }
            else if (season == "Summer")
            {
                Console.WriteLine("No lectures! It's summer!");
            }

        }
    }
}
