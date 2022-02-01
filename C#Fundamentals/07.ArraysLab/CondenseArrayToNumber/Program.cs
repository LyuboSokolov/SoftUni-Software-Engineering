using System;
using System.Linq;

namespace CondenseArrayToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray();

            int[] numbers2 = new int[numbers.Length];
            int sum = 0;
            int allSum = 0;
            int V = numbers.Length;

            while (V > 1)
            {
                for (int i = 0; i < V; i++)
                {
                    if (i + 1 < V)
                    {
                        numbers2[i] = numbers[i] + numbers[i + 1];
                        sum = numbers[i] + numbers[i + 1];
                    }
                }
                numbers = numbers2;
                V -= 1;
                if (V <= 2)
                {
                    break;
                }
            }

            if (numbers.Length == 1)
            {
                allSum = numbers[0];
            }
            else
            {
                allSum = numbers[0] + numbers[1];
            }
            Console.WriteLine(allSum);

        }
    }
}
