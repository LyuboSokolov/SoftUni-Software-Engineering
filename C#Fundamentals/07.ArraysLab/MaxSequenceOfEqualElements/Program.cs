using System;
using System.Linq;

namespace MaxSequenceОфEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToArray();
            int lastNumber = 0;
            int count = 1;
            int bigSequence = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (count > bigSequence)
                {
                    bigSequence = count;
                    lastNumber = arr[i];
                }
                count = 1;
            }

            for (int i = 0; i < bigSequence; i++)
            {
                Console.Write($"{lastNumber} ");
            }
        }
    }
}
