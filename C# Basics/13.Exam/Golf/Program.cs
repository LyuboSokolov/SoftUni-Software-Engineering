using System;

namespace Golf
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberStroke = int.Parse(Console.ReadLine());
            int numbersHoles = int.Parse(Console.ReadLine());
            double sum = 0;
            double allSum = 0;
            int count = 0;
            string ForceStroke = string.Empty;
            double totalSum = 0;
            int allCount = 0;
            int forceToNextHole = 0;

            for (int i = 0; i < numbersHoles; i++)
            {
                forceToNextHole = 0;
                forceToNextHole = int.Parse(Console.ReadLine());
                while (totalSum < forceToNextHole)
                {
                    ForceStroke = Console.ReadLine();
                    allCount++;
                    count++;

                    for (int j = 0; j < ForceStroke.Length; j++)
                    {
                        sum += ForceStroke[j];
                    }
                    allSum = sum / ForceStroke.Length;
                    sum = 0;
                    totalSum += allSum;
                    if (totalSum >= forceToNextHole)
                    {
                        Console.WriteLine($"New hole reached! Hits so far: {count}");

                        totalSum = 0;
                        allSum = 0;
                        sum = 0;
                        break;
                    }
                }
            }
            if (allCount < numberStroke)
            {
                Console.WriteLine($"Yes, you won! Total hits: {allCount}");
            }
            else
            {
                Console.WriteLine($"Better luck next time... Total hits: {allCount}");
            }

        }


    }
}

