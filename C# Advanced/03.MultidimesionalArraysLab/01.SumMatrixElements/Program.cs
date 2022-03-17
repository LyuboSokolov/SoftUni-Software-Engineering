using System;
using System.Linq;

namespace _01.SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int row = input[0];
            int col = input[1];
            int sum = 0;

            int[,] matrix = new int[row, col];

            for (int i = 0; i < row; i++)
            {
                input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    sum += matrix[i, j];
                }
                
            }

            Console.WriteLine(row);
            Console.WriteLine(col);
            Console.WriteLine(sum);
        }
    }
}
