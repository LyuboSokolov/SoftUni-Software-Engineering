using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];

            char[,] matrix = new char[rows, cols];

            string snake = Console.ReadLine();
            Queue<char> snakesQueue = new Queue<char>(snake);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    char currChar = '\n';
                    if (row % 2 == 0)
                    {
                        matrix[row, col] = snakesQueue.Peek();
                        currChar = snakesQueue.Dequeue();
                        snakesQueue.Enqueue(currChar);
                    }
                    else
                    {
                        matrix[row, cols - 1 - col] = snakesQueue.Peek();
                        currChar = snakesQueue.Dequeue();
                        snakesQueue.Enqueue(currChar);
                    }
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }

        }
    }
}
