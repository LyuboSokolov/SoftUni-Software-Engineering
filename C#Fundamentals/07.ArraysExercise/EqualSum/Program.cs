using System;
using System.Linq;

namespace EqualSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToArray();
            int leftSum = 0;
            int rightSum = 0;
            bool isEqual = false;

            for (int curr = 0; curr < arr.Length; curr++)
            {
                rightSum = 0;
                for (int i = curr + 1; i < arr.Length; i++)
                {
                    rightSum += arr[i];
                }

                leftSum = 0;
                for (int j = curr - 1; j >= 0; j--)
                {
                    leftSum += arr[j];
                }
                if (rightSum == leftSum)
                {
                    Console.WriteLine(curr);
                    isEqual = true;
                    break;
                }
            }
            if (!isEqual && arr.Length > 1)
            {
                Console.WriteLine("no");
            }
            if (rightSum != leftSum && arr.Length == 1)
            {
                Console.WriteLine("0");
            }
        }
    }
}

