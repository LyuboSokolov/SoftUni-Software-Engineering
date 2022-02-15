using System;
using System.Collections.Generic;
using System.Linq;

namespace BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbersSequence = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToList();

            int[] bombNumberAndPower = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int bombNumber = bombNumberAndPower[0];
            int powerNumber = bombNumberAndPower[1];

            for (int i = 0; i < numbersSequence.Count; i++)
            {


                if (bombNumber == numbersSequence[i])
                {
                    int startIndex = i - powerNumber;
                    int endIndex = i + powerNumber;

                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }
                    if (endIndex > numbersSequence.Count - 1)
                    {
                        endIndex = numbersSequence.Count - 1;
                    }

                    numbersSequence.RemoveRange(startIndex, endIndex - startIndex + 1);
                    i = startIndex - 1;
                }



            }

            Console.WriteLine(numbersSequence.Sum());
        }
    }
}
