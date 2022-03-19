using System;
using System.Linq;

namespace _06.Jagged_ArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] matrix = new int[n][];

            for (int row = 0; row < n; row++)
            {
                int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                matrix[row] = new int[inputNumbers.Length];

                for (int col = 0; col < inputNumbers.Length; col++)
                {
                    matrix[row][col] = inputNumbers[col];
                }
            }
            string[] inputCommand = Console.ReadLine().Split();

            while (inputCommand[0] != "END")
            {
                string command = inputCommand[0];
                int currRow = int.Parse(inputCommand[1]);
                int currCol = int.Parse(inputCommand[2]);
                int number = int.Parse(inputCommand[3]);

                if (currRow > n - 1 || currRow < 0 ||
                    currCol > n - 1 || currCol < 0)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else
                {
                    if (command == "Add")
                    {
                        matrix[currRow][currCol] += number;
                    }
                    else if (command == "Subtract")
                    {
                        matrix[currRow][currCol] -= number;
                    }
                }
                inputCommand = Console.ReadLine().Split();
            }
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
