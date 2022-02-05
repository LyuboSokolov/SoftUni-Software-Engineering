using System;
using System.Linq;

namespace CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine().Split().ToArray();
            string[] arr2 = Console.ReadLine().Split().ToArray();
            int lenghtResult = 0;

            if (arr1.Length > arr2.Length)
            {
                lenghtResult = arr1.Length;
            }
            else
            {
                lenghtResult = arr2.Length;
            }

            string[] results = new string[lenghtResult];

            for (int i = 0; i < arr1.Length; i++)
            {
                for (int j = 0; j < arr2.Length; j++)
                {
                    if (arr2[j] == arr1[i])
                    {
                        Console.Write($"{arr2[j]} ");
                    }
                }
            }
        }
    }
}
