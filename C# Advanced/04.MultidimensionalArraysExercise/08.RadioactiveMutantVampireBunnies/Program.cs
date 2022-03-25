using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];
            int currRowPlayer = -1;
            int currColPlayer = -1;

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                    if (input[col] == 'P')
                    {
                        currRowPlayer = row;
                        currColPlayer = col;
                    }
                }
            }

            string inputMove = Console.ReadLine();
            bool isDead = false;
            bool isWon = false;

            for (int i = 0; i < inputMove.Length; i++)
            {
                char direction = inputMove[i];

                if (direction == 'R')
                {
                    if (currColPlayer < matrix.GetLength(1) - 1)
                    {
                        if (matrix[currRowPlayer, currColPlayer + 1] == '.')
                        {
                            matrix[currRowPlayer, currColPlayer + 1] = 'P';
                            matrix[currRowPlayer, currColPlayer] = '.';
                            currColPlayer++;
                        }
                        else
                        {
                            matrix[currRowPlayer, currColPlayer] = '.'; // TODO
                            currColPlayer++;
                            isDead = true;
                        }
                    }
                    else
                    {
                        matrix[currRowPlayer, currColPlayer] = '.'; // TODO
                        isWon = true;

                    }
                }
                else if (direction == 'L')
                {
                    if (currColPlayer - 1 >= 0)
                    {
                        if (matrix[currRowPlayer, currColPlayer - 1] == '.')
                        {
                            matrix[currRowPlayer, currColPlayer - 1] = 'P';
                            matrix[currRowPlayer, currColPlayer] = '.';
                            currColPlayer--;
                        }
                        else
                        {
                            matrix[currRowPlayer, currColPlayer] = '.'; // TODO
                            currColPlayer--;
                            isDead = true;
                        }
                    }
                    else
                    {
                        matrix[currRowPlayer, currColPlayer] = '.'; // TODO
                        isWon = true;

                    }
                }
                else if (direction == 'U')
                {
                    if (currRowPlayer - 1 >= 0)
                    {
                        if (matrix[currRowPlayer - 1, currColPlayer] == '.')
                        {
                            matrix[currRowPlayer - 1, currColPlayer] = 'P';
                            matrix[currRowPlayer, currColPlayer] = '.';
                            currRowPlayer--;
                        }
                        else
                        {
                            matrix[currRowPlayer, currColPlayer] = '.'; // TODO
                            currRowPlayer--;
                            isDead = true;
                        }
                    }
                    else
                    {
                        matrix[currRowPlayer, currColPlayer] = '.'; // TODO
                        isWon = true;
                    }
                }
                else if (direction == 'D')
                {
                    if (currRowPlayer < matrix.GetLength(0) - 1)
                    {
                        if (matrix[currRowPlayer + 1, currColPlayer] == '.')
                        {
                            matrix[currRowPlayer + 1, currColPlayer] = 'P';
                            matrix[currRowPlayer, currColPlayer] = '.';
                            currRowPlayer++;
                        }
                        else
                        {
                            matrix[currRowPlayer, currColPlayer] = '.'; // TODO
                            currRowPlayer++;
                            isDead = true;
                        }
                    }
                    else
                    {
                        matrix[currRowPlayer, currColPlayer] = '.'; // TODO
                        isWon = true;
                    }
                }

                // КАК ДА РАЗПРОСТРАНЯВАМ ЗАЙЦИТЕ ???

                List<int[]> bunniesCoordinates = GetBunniesCoordinates(matrix);
                SpreadBunnies(bunniesCoordinates, matrix);





                if (matrix[currRowPlayer, currColPlayer] == 'B')
                {
                    isDead = true;
                }

                if (isDead || isWon)
                {
                    break;
                }

            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
            if (isDead)
            {
                Console.WriteLine($"dead: {currRowPlayer} {currColPlayer}");
            }
            else 
            {
                Console.WriteLine($"won: {currRowPlayer} {currColPlayer}");
            }

        }

        private static void SpreadBunnies(List<int[]> bunniesCoordinates, char[,] matrix)
        {
            foreach (int[] bunnyCoordinates in bunniesCoordinates)
            {
                int row = bunnyCoordinates[0];
                int col = bunnyCoordinates[1];
                SpreadBunny(row - 1, col, matrix);
                SpreadBunny(row + 1, col, matrix);
                SpreadBunny(row, col - 1, matrix);
                SpreadBunny(row, col + 1, matrix);
            }
        }

        private static void SpreadBunny(int row, int col, char[,] matrix)
        {
            int rowsLenght = matrix.GetLength(0);
            int colsLenght = matrix.GetLength(1);

            if (IsValidCell(row, col, rowsLenght, colsLenght))
            {
                matrix[row, col] = 'B';
            }
        }

        private static bool IsValidCell(int row, int col, int n, int m)
        {
            return row >= 0 && row < n && col >= 0 && col < m;
        }

        private static List<int[]> GetBunniesCoordinates(char[,] matrix)
        {
            List<int[]> bunniesCoordinates = new List<int[]>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        bunniesCoordinates.Add(new int[] { row, col });
                    }
                }
            }
            return bunniesCoordinates;
        }
    }
}
