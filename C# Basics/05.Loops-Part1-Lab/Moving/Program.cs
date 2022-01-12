using System;

namespace Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int w = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());
            string input = String.Empty;
            int box = 0;
            int allBox = 0;
            int freeSpace = 0;

            freeSpace = w * l * h;

            while (input != "Done")
            {
                input = Console.ReadLine();
                if (input == "Done")
                {
                    Console.WriteLine($"{freeSpace - allBox} Cubic meters left.");
                    break;

                }
                box = int.Parse(input);
                allBox += box;
                if (allBox > freeSpace)
                {
                    Console.WriteLine($"No more free space! You need {allBox - freeSpace} Cubic meters more.");
                    break;
                }
            }
        }
    }
}
