using System;

namespace ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int badEvaluation = int.Parse(Console.ReadLine());
            string input = string.Empty;
            int numberOfBadE = 0;
            double absEvaluation = 0;
            int counter = 0;
            string lastProblem = string.Empty;

            while (input != "Enough")
            {
                input = Console.ReadLine();
                if (input != "Enough")
                {
                    lastProblem = input;
                }
                int evaluation = int.Parse(Console.ReadLine());
                absEvaluation += evaluation;
                counter++;

                if (evaluation <= 4)
                {
                    numberOfBadE++;
                    if (numberOfBadE >= badEvaluation)
                    {
                        Console.WriteLine($"You need a break, {numberOfBadE} poor grades.");
                        break;
                    }
                }
                if (input == "Enough")
                {
                    double ocenka = absEvaluation / counter;
                    Console.WriteLine($"Average score: {ocenka}");
                    Console.WriteLine($"Number of problems: {counter}");
                    Console.WriteLine($"Last problem:{lastProblem}");
                }
            }
        }
    }
}
