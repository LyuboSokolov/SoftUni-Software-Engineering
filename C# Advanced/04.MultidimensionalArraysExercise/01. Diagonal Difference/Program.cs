using System;
using System.Linq;

namespace _01.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = inputNumbers[col];
                }
            }
            int sumRight = 0;
            int sumLeft = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                sumRight += matrix[row, row];
                sumLeft += matrix[row, matrix.GetLength(0) - 1 - row];
            }

            Console.WriteLine(Math.Abs(sumRight-sumLeft));
        }
    }
}
