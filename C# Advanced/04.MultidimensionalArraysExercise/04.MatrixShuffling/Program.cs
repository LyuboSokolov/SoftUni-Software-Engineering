using System;
using System.Linq;

namespace _04.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = input[0];
            int cols = input[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] inputData = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = inputData[col];
                }
            }

            string[] inputCommandAndCoor = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (inputCommandAndCoor[0] != "END")
            {
                if (inputCommandAndCoor.Length != 5 || !inputCommandAndCoor.Contains("swap"))
                {
                    Console.WriteLine("Invalid input!");
                    inputCommandAndCoor = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }
                string command = inputCommandAndCoor[0];
                int row1 = int.Parse(inputCommandAndCoor[1]);
                int col1 = int.Parse(inputCommandAndCoor[2]);
                int row2 = int.Parse(inputCommandAndCoor[3]);
                int col2 = int.Parse(inputCommandAndCoor[4]);

                if (isValidCoordinates(row1, col1, row2, col2, matrix) == false)
                {
                    Console.WriteLine("Invalid input!");
                    inputCommandAndCoor = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }
                if (command == "swap")
                {
                    string first = matrix[row1, col1];
                    string second = matrix[row2, col2];
                    matrix[row1, col1] = second;
                    matrix[row2, col2] = first;

                    for (int row = 0; row < rows; row++)
                    {
                        for (int col = 0; col < cols; col++)
                        {
                            Console.Write(matrix[row, col] + " ");
                        }
                        Console.WriteLine();
                    }
                }
                inputCommandAndCoor = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
        }

        private static bool isValidCoordinates(int row1, int col1, int row2, int col2, string[,] matrix)
        {
            bool isValid = false;
            if (row1 >= 0 && row1 < matrix.GetLength(0) &&
                row2 >= 0 && row2 < matrix.GetLength(0) &&
                col1 >= 0 && col1 < matrix.GetLength(1) &&
                col2 >= 0 && col2 < matrix.GetLength(1))
            {
                isValid = true;
            }
            return isValid;
        }
    }
}

