using System;
using System.Linq;

namespace ShootForTheWin
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string input = Console.ReadLine();

            int count = 0;
            int currentTarget = 0;

            while (input?.ToUpper() != "END")
            {
                int index = int.Parse(input);

                if (index >= 0 && index < targets.Length)
                {
                    currentTarget = targets[index];
                    targets[index] = -1;
                    count++;
                }
                else
                {
                    input = Console.ReadLine();
                    continue;
                }

                for (int i = 0; i < targets.Length; i++)
                {
                    if (targets[i] <= currentTarget && targets[i] != -1)
                    {
                        targets[i] += currentTarget;
                    }
                    else if (targets[i] > currentTarget && targets[i] != -1)
                    {
                        targets[i] -= currentTarget;
                    }
                }



                input = Console.ReadLine();
            }

            Console.WriteLine($"Shot targets: {count} -> {string.Join(' ', targets)}");
        }
    }
}
