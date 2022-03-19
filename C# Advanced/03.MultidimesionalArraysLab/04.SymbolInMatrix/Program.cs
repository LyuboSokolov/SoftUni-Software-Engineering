using System;
using System.Linq;

namespace _04.SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            bool isFind = false;
            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col] ;
                }
            }

            char inputSumbol = char.Parse(Console.ReadLine());
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row,col] == inputSumbol)
                    {
                        isFind = true;
                        Console.WriteLine($"({row}, {col})");
                        break;
                    }
                    if (isFind)
                    {
                        break;
                    }
                    
                }
            }
            if (isFind == false)
            {
                Console.WriteLine($"{inputSumbol} does not occur in the matrix");
            }
        }
    }
}
