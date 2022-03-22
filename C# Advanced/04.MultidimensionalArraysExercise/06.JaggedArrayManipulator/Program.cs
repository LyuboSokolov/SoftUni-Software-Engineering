using System;
using System.Linq;

namespace _06.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            double[][] jaggedMatrix = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] inputNumbers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                jaggedMatrix[row] = new double[inputNumbers.Length];

                for (int col = 0; col < inputNumbers.Length; col++)
                {
                    jaggedMatrix[row][col] = inputNumbers[col];
                }
            }

            for (int row = 0; row < rows - 1; row++)
            {
                if (jaggedMatrix[row].Length == jaggedMatrix[row + 1].Length)
                {
                    for (int col = 0; col < jaggedMatrix[row].Length; col++)
                    {
                        jaggedMatrix[row][col] *= 2;
                    }
                    for (int col = 0; col < jaggedMatrix[row + 1].Length; col++)
                    {
                        jaggedMatrix[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jaggedMatrix[row].Length; col++)
                    {
                        if (jaggedMatrix[row][col] != 0)
                        {
                            jaggedMatrix[row][col] /= 2;
                        }

                    }
                    for (int col = 0; col < jaggedMatrix[row + 1].Length; col++)
                    {
                        if (jaggedMatrix[row + 1][col] != 0)
                        {
                            jaggedMatrix[row + 1][col] /= 2;
                        }

                    }
                }
            }
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "End")
            {
                string command = input[0];
                int currRow = int.Parse(input[1]);
                int currCol = int.Parse(input[2]);
                int value = int.Parse(input[3]);

                if (currRow < 0 || currRow >= jaggedMatrix.Length ||
                    currCol < 0 || currCol >= jaggedMatrix[currRow].Length)
                {
                    input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }

                if (command == "Add")
                {
                    jaggedMatrix[currRow][currCol] += value;
                }
                else if (command == "Subtract")
                {
                    jaggedMatrix[currRow][currCol] -= value;
                }
                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < jaggedMatrix[row].Length; col++)
                {
                    Console.Write(jaggedMatrix[row][col] + " ");
                }
                Console.WriteLine();
            }


        }
    }
}
