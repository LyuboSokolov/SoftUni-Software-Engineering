using System;

namespace TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersOfJuri = int.Parse(Console.ReadLine());
            string namePresentation = Console.ReadLine();
            int count = 0;
            double sumEvaluation = 0;
            double evaluation = 0;
            double totalEvaluation = 0;

            while (namePresentation != "Finish")
            {
                for (int i = 1; i <= numbersOfJuri; i++)
                {
                    evaluation = double.Parse(Console.ReadLine());
                    count++;
                    sumEvaluation += evaluation;
                }

                Console.WriteLine($"{namePresentation} - {sumEvaluation / numbersOfJuri:f2}.");
                totalEvaluation += sumEvaluation;
                sumEvaluation = 0;
                namePresentation = Console.ReadLine();
            }
            Console.WriteLine($"Student's final assessment is {totalEvaluation / count:f2}.");
        }
    }
}
