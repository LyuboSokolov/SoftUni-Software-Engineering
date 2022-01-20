using System;

namespace LoadSuitcases
{
    class Program
    {
        static void Main(string[] args)
        {
            double freeSize = double.Parse(Console.ReadLine());
            string input = string.Empty;
            double sizeSuitcases = 0;
            double busySpace = 0;
            int count = 0;
            int countAllSuitcases = 0;

            while (input != "End")
            {
                input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                sizeSuitcases = double.Parse(input);

                count++;
                if (count >= 3)
                {
                    sizeSuitcases *= 1.10;
                    count = 0;
                }
                busySpace += sizeSuitcases;
                sizeSuitcases = 0;
                if (busySpace > freeSize)
                {
                    Console.WriteLine("No more space!");
                    break;
                }
                countAllSuitcases++;

            }
            if (input == "End")
            {
                Console.WriteLine("Congratulations! All suitcases are loaded!");
            }
            Console.WriteLine($"Statistic: {countAllSuitcases} suitcases loaded.");
        }
    }
}
