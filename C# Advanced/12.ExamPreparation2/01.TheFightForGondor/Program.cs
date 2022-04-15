using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem._01
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersOfWaves = int.Parse(Console.ReadLine());

            Queue<int> plates = new Queue<int>(Console.ReadLine()
                                     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                     .Select(int.Parse));


            int countWave = 0;
            bool isOrcWin = false;
            Stack<int> wave = new Stack<int>();
            for (int i = 0; i < numbersOfWaves; i++)
            {
                if (isOrcWin)
                {
                    break;
                }
                wave = new Stack<int>(Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse));

                countWave++;

                if (countWave == 3)
                {
                    plates.Enqueue(int.Parse(Console.ReadLine()));
                    countWave = 0;
                }


                while (wave.Count > 0 && plates.Count > 0)
                {
                    int currWorrier = wave.Peek();
                    int currPlate = plates.Peek();

                    if (currWorrier > currPlate)
                    {
                        plates.Dequeue();
                        currWorrier -= currPlate;
                        wave.Pop();
                        wave.Push(currWorrier);
                    }

                    else if (currWorrier < currPlate)
                    {
                        /// shte ima problem
                        wave.Pop();
                        currPlate -= currWorrier;
                        plates.Dequeue();

                        List<int> result = new List<int>();
                        result.Add(currPlate);

                        foreach (var item in plates)
                        {
                            result.Add(item);
                        }
                        plates = new Queue<int>(result);


                    }
                    else
                    {
                        wave.Pop();
                        plates.Dequeue();
                    }

                    if (plates.Count == 0)
                    {
                        isOrcWin = true;
                        break;
                    }
                }

            }
            if (isOrcWin)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", wave)}");
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }

        }
    }
}
