using System;
using System.Collections.Generic;
using System.Linq;

namespace Warship
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            List<int[]> commands = new List<int[]>();

            string[] input = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                int[] currCommand = input[i].Split(" ").Select(int.Parse).ToArray();

                commands.Add(currCommand);
            }

            

            for (int row = 0; row < n; row++)
            {
                string[] inputDataMatrix = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = char.Parse(inputDataMatrix[col]);

                }
            }
            int countFirstPlayerShips = 0;
            int countSocondPlayerShips = 0;
            int countDestroyFirstPlayerShips = 0;
            int countDestroySecondPlayerShips = 0;

            for (int i = 0; i < commands.Count; i++)
            {
                countFirstPlayerShips = 0;
                countSocondPlayerShips = 0;

                int currRow = commands[i][0];
                int currCol = commands[i][1];

                if (IsValidCoordination(matrix, currRow, currCol))
                {
                    if (i % 2 == 0)
                    {
                        if (matrix[currRow, currCol] == '#')
                        {
                            countDestroyFirstPlayerShips += AttackMine(matrix, currRow, currCol);
                        }
                        else if (matrix[currRow, currCol] == '<')
                        {
                            continue;

                        }
                        else if (matrix[currRow, currCol] == '>')
                        {
                            matrix[currRow, currCol] = 'X';
                            countDestroyFirstPlayerShips++;

                        }
                    }
                    else
                    {

                        if (matrix[currRow, currCol] == '#')
                        {
                            countDestroySecondPlayerShips += AttackMine(matrix, currRow, currCol);
                        }
                        else if (matrix[currRow, currCol] == '<')
                        {
                            matrix[currRow, currCol] = 'X';
                            countDestroySecondPlayerShips++;

                        }
                        else if (matrix[currRow, currCol] == '>')
                        {
                            continue;
                        }

                    }

                }
                else
                {
                    continue;
                }

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (matrix[row, col] == '<')
                        {
                            countFirstPlayerShips++;
                        }
                        else if (matrix[row, col] == '>')
                        {
                            countSocondPlayerShips++;
                        }
                    }

                }

                if (countFirstPlayerShips == 0 || countSocondPlayerShips == 0)
                {
                    break;
                }
            }


            if (countFirstPlayerShips > 0 && countSocondPlayerShips > 0)
            {
                Console.WriteLine($"It's a draw! Player One has {countFirstPlayerShips} ships left. Player Two has {countSocondPlayerShips} ships left.");
            }
            else if (countFirstPlayerShips > 0 && countSocondPlayerShips <= 0)
            {
                Console.WriteLine($"Player One has won the game! {countDestroyFirstPlayerShips + countDestroySecondPlayerShips} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"Player Two has won the game! {countDestroyFirstPlayerShips + countDestroySecondPlayerShips} ships have been sunk in the battle.");
            }

            

        }

        public static int AttackMine(char[,] matrix, int mineRow, int mineCol)
        {
            matrix[mineRow, mineRow] = 'X';
            int destroyShips = 0;
            for (int row = mineRow - 1; row <= mineRow + 1; row++)
            {
                for (int col = mineCol - 1; col <= mineCol + 1; col++)
                {
                    if (IsValidCoordination(matrix, row, col))
                    {
                        if (matrix[row, col] == '>' || matrix[row, col] == '<')
                        {
                            destroyShips++;
                        }
                        matrix[row, col] = 'X';
                    }
                }
            }


            return destroyShips;
        }



        public static bool IsValidCoordination(char[,] matrix, int currRow, int currCol)
        {
            if (currRow < 0 || currRow >= matrix.GetLength(0) || currCol < 0 || currCol >= matrix.GetLength(1))
            {
                return false;
            }
            return true;
        }
    }
}
