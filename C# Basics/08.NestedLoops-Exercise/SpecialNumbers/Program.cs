using System;

namespace SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 9; i++)
            {
                if (N % i == 0)
                {
                    for (int j = 1; j <= 9; j++)
                    {
                        if (N % j == 0)
                        {

                            for (int k = 1; k <= 9; k++)
                            {
                                if (N % k == 0)
                                {
                                    for (int l = 1; l <= 9; l++)
                                    {
                                        if (N % l == 0)
                                        {
                                            Console.Write($"{i}{j}{k}{l} ");
                                        }
                                    }
                                }

                            }
                        }

                    }
                }

            }
        }
    }
}
