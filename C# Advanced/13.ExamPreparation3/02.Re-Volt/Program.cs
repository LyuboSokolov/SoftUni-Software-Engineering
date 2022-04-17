using System;

namespace _02.Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());

            int countCommands = int.Parse(Console.ReadLine());

            char[,] matrix = new char[sizeMatrix, sizeMatrix];
            int playerRow = -1;
            int playerCol = -1;
            bool isWon = false;

            for (int row = 0; row < sizeMatrix; row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < sizeMatrix; col++)
                {
                    matrix[row, col] = input[col];

                    if (input[col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            for (int i = 0; i < countCommands; i++)
            {
                string input = Console.ReadLine();
                int oldPositionRow = playerRow;
                int oldPositionCol = playerCol;
                matrix[playerRow, playerCol] = '-';

                if (input == "up")
                {
                    playerRow--;
                    if (playerRow < 0)
                    {
                        playerRow = sizeMatrix - 1;
                    }
                }
                else if (input == "down")
                {
                    playerRow++;
                    if (playerRow == sizeMatrix)
                    {
                        playerRow = 0;
                    }
                }
                else if (input == "left")
                {
                    playerCol--;
                    if (playerCol < 0)
                    {
                        playerCol = sizeMatrix - 1;
                    }
                }
                else if (input == "right")
                {
                    playerCol++;
                    if (playerCol == sizeMatrix)
                    {
                        playerCol = 0;
                    }
                }

                if (matrix[playerRow, playerCol] == 'B')
                {
                    if (input == "up")
                    {
                        playerRow--;
                        if (playerRow < 0)
                        {
                            playerRow = sizeMatrix - 1;
                        }
                    }
                    else if (input == "down")
                    {
                        playerRow++;
                        if (playerRow == sizeMatrix)
                        {
                            playerRow = 0;
                        }
                    }
                    else if (input == "left")
                    {
                        playerCol--;
                        if (playerCol < 0)
                        {
                            playerCol = sizeMatrix - 1;
                        }
                    }
                    else if (input == "right")
                    {
                        playerCol++;
                        if (playerCol == sizeMatrix)
                        {
                            playerCol = 0;
                        }
                    }
                }
                if (matrix[playerRow, playerCol] == 'T')
                {
                    playerCol = oldPositionCol;
                    playerRow = oldPositionRow;
                    matrix[playerRow, playerCol] = 'f';
                }
                if (matrix[playerRow, playerCol] == 'F')
                {
                    matrix[playerRow, playerCol] = 'f';
                    isWon = true;
                    break;
                }
                else if (matrix[playerRow, playerCol] == '-')
                {
                    matrix[playerRow, playerCol] = 'f';
                }
            }

            if (isWon)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            for (int row = 0; row < sizeMatrix; row++)
            {
                for (int col = 0; col < sizeMatrix; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
