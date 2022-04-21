using System;

namespace _02.SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int livesOfMario = int.Parse(Console.ReadLine());
            int rowsOfJaggedMatrix = int.Parse(Console.ReadLine());

            char[][] jaggedMatrix = new char[rowsOfJaggedMatrix][];

            int marioRow = -1;
            int marioCol = -1;

            for (int row = 0; row < rowsOfJaggedMatrix; row++)
            {
                string input = Console.ReadLine();
                jaggedMatrix[row] = new char[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    jaggedMatrix[row][col] = input[col];

                    if (input[col] == 'M')
                    {
                        marioRow = row;
                        marioCol = col;
                    }
                }
            }
            int matrixColum = jaggedMatrix[0].Length;
            bool marioDead = false;
            bool marioWin = false;

            while (true)
            {
                string[] inputCommand = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string directionMario = inputCommand[0];
                int enemySpawRow = int.Parse(inputCommand[1]);
                int enemySpawCol = int.Parse(inputCommand[2]);

                jaggedMatrix[enemySpawRow][enemySpawCol] = 'B';

                int oldMarioRow = marioRow;
                int oldMarioCol = marioCol;
                jaggedMatrix[oldMarioRow][oldMarioCol] = '-';

                if (directionMario == "W")
                {
                    marioRow--;
                }
                else if (directionMario == "S")
                {
                    marioRow++;
                }
                else if (directionMario == "A")
                {
                    marioCol--;
                }
                else if (directionMario == "D")
                {
                    marioCol++;
                }

                if (marioRow < 0 || marioRow == rowsOfJaggedMatrix || marioCol < 0 || marioCol == matrixColum)
                {
                    livesOfMario--;
                    marioRow = oldMarioRow;
                    marioCol = oldMarioCol;

                    if (livesOfMario <=0) //TODO:
                    {
                        jaggedMatrix[marioRow][marioCol] = 'X';
                        marioDead = true;
                        Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                        break;
                    }
                 
                    continue;
                }
                else if (jaggedMatrix[marioRow][marioCol] == 'B')
                {
                    livesOfMario -= 3;
                    if (livesOfMario<=0)
                    {
                        jaggedMatrix[marioRow][marioCol] = 'X';
                        marioDead = true;
                        Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                        break;
                    }
                    else
                    {
                        jaggedMatrix[marioRow][marioCol] = '-';
                    }
                }
                else if (jaggedMatrix[marioRow][marioCol] == 'P')
                {
                    livesOfMario--;
                    if (livesOfMario<0)
                    {
                        livesOfMario = 0;
                    }
                    jaggedMatrix[marioRow][marioCol] = '-';
                    marioWin = true;
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {livesOfMario}");
                    break;
                }
                else if (jaggedMatrix[marioRow][marioCol] == '-')
                {
                    livesOfMario--;
                    if (livesOfMario <= 0 )
                    {
                        jaggedMatrix[marioRow][marioCol] = 'X';
                        marioDead = true;
                        Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                        break;
                    }
                }
            }

            for (int row = 0; row < rowsOfJaggedMatrix; row++)
            {
                for (int col = 0; col < jaggedMatrix[row].Length; col++)
                {
                    Console.Write(jaggedMatrix[row][col]);
                }
                Console.WriteLine();
            }
        }
    }
}
