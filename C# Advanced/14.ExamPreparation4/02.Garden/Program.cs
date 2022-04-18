using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Garden
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];

            int[,] matrix = new int[rows, cols];

            List<int> positionFurion = new List<int>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Bloom Bloom Plow")
                {
                    for (int row = 0; row < rows; row++)
                    {
                        for (int col = 0; col < cols; col++)
                        {
                            if (matrix[row, col] != 0)
                            {
                                positionFurion.Add(row);
                                positionFurion.Add(col);
                            }
                        }
                    }
                    break;
                }

                int[] currRowAndCol = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int currRow = currRowAndCol[0];
                int currCol = currRowAndCol[1];

                if (isValidCoordination(currRow, currCol, rows, cols))
                {
                    matrix[currRow, currCol]++;
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }

            }

            for (int i = 0; i < positionFurion.Count; i+=2)
            {
                int row = positionFurion[i];
                int col = positionFurion[i+1];

                for (int curRow = 0; curRow < rows; curRow++)
                {
                    if (curRow == row)
                    {
                        continue;
                    }
                    matrix[curRow, col]++;
                }
                for (int curCol = 0; curCol < cols; curCol++)
                {
                    if (curCol==col)
                    {
                        continue;
                    }
                    matrix[row, curCol]++;
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row,col]+" ");
                }
                Console.WriteLine();
            }

        }

        private static bool isValidCoordination(int currRow, int currCol, int rows, int cols)
        {
            if (currRow >= 0 && currRow <= rows && currCol >= 0 && currCol <= cols)
            {
                return true;
            }
            return false;
        }
    }
}
