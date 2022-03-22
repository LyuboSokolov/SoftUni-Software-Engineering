using System;
using System.Linq;

namespace _03.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int n = 3; // Square 3x3 -> can change this
            int rows = input[0];
            int cols = input[1];

            int[,] matrix = new int[rows, cols];
            int maxSum = int.MinValue;

            for (int row = 0; row < rows; row++)
            {
                input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            int currRow = 0;
            int currCol = 0;
            for (int row = 0; row < rows - n + 1; row++)
            {
                for (int col = 0; col < cols - n + 1; col++)
                {
                    int currentSum = 0;
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            currentSum += matrix[row + i, col + j];
                        }
                    }
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        currRow = row;
                        currCol = col;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            for (int row = currRow; row < currRow + n; row++)
            {
                for (int col = currCol; col < currCol + n; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
