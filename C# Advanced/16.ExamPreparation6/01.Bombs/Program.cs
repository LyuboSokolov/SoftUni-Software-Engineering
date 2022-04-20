using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> bombEffects = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> bombCasing = new Stack<int>(Console.ReadLine()
              .Split(", ", StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToArray());

            // Datura Bombs: 40
            //•	Cherry Bombs: 60
            //•	Smoke Decoy Bombs: 120

            int daturaBombCount = 0;
            int cherryBombCount = 0;
            int smokeDecoyBombs = 0;

            bool isSuccessCreatePunch = false;

            while (bombEffects.Count > 0 && bombCasing.Count > 0)
            {
                bool isCreatBomb = true;

                int currBombEffect = bombEffects.Dequeue();
                int currBombCasing = bombCasing.Pop();

                if (currBombEffect + currBombCasing < 40)
                {
                    bombEffects.Enqueue(currBombEffect);
                    bombCasing.Push(currBombCasing);
                    continue;
                }

                while (true)
                {
                    if (currBombEffect + currBombCasing == 120)
                    {
                        smokeDecoyBombs++;
                        break;
                    }
                    else if (currBombEffect + currBombCasing == 60)
                    {
                        cherryBombCount++;
                        break;
                    }
                    else if (currBombEffect + currBombCasing == 40)
                    {
                        daturaBombCount++;
                        break;
                    }
                    else if (currBombCasing >= 5)
                    {
                        currBombCasing -= 5;
                    }
                    else if (currBombCasing < 5)
                    {
                        isCreatBomb = false;
                        break;
                    }
                }

                if (isCreatBomb == false)
                {
                    bombEffects.Enqueue(currBombEffect);
                }
                if (daturaBombCount >= 3 && cherryBombCount >= 3 && smokeDecoyBombs >= 3)
                {
                    isSuccessCreatePunch = true;
                    break;
                }

            }

            if (isSuccessCreatePunch)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffects.Count>0)
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ",bombEffects)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (bombCasing.Count > 0)
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasing)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            Console.WriteLine($"Cherry Bombs: {cherryBombCount}");
            Console.WriteLine($"Datura Bombs: {daturaBombCount}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeDecoyBombs}");
        }
    }
}
