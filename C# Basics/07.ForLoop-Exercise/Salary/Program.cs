using System;

namespace Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int numPages = int.Parse(Console.ReadLine());
            int solary = int.Parse(Console.ReadLine());

            for (int i = 0; i < numPages; i++)
            {
                string input = Console.ReadLine();
                if (input == "Facebook")
                {
                    solary -= 150;
                }
                else if (input == "Instagram")
                {
                    solary -= 100;
                }
                else if (input == "Reddit")
                {
                    solary -= 50;
                }
                if (solary <= 0)
                {
                    Console.WriteLine("You have lost your salary.");
                    break;
                }
            }
            if (solary > 0)
            {
                Console.WriteLine(solary);
            }
        }
    }
}
