using System;
using System.Linq;

namespace _02.Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());

            char[,] matrix = new char[sizeMatrix, sizeMatrix];

            int snakeRow = -1;
            int snakeCol = -1;
            int eatonFood = 0;

            for (int row = 0; row < sizeMatrix; row++)
            {
               char[]  input = Console.ReadLine().ToArray();

                for (int col = 0; col < sizeMatrix; col++)
                {
                    matrix[row, col] = input[col];

                    if (input[col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                }
            }

            bool snakeOutOfTeritory = false;

            while (true)
            {
                string inputCommand = Console.ReadLine();
                matrix[snakeRow, snakeCol] = '.';


                switch (inputCommand)
                {
                    case "up": snakeRow--;
                        break;
                    case "down": snakeRow++;
                        break;
                    case "left": snakeCol--;
                        break;
                    case "right": snakeCol++;
                        break;
                    default:
                        break;
                }
                if (snakeRow < 0 || snakeRow >= sizeMatrix || snakeCol <0 || snakeCol >=sizeMatrix)
                {
                    snakeOutOfTeritory = true;
                    break;
                }

                if (matrix[snakeRow,snakeCol] == '*')
                {
                    eatonFood++;
                    matrix[snakeRow, snakeCol] = 'S';
                }
                else if (matrix[snakeRow,snakeCol] == 'B')
                {
                    bool isFind = false;
                    for (int row = 0; row < sizeMatrix; row++)
                    {
                        for (int col = 0; col < sizeMatrix; col++)
                        {
                            if (matrix[row,col]=='B' && (snakeRow != row || snakeCol != col))
                            {
                                matrix[snakeRow, snakeCol] = '.';
                                snakeRow = row;
                                snakeCol = col;
                                isFind = true;
                                break;
                            }
                           
                        }
                        if (isFind)
                        {
                            break;
                        }
                    }
                }


                if (eatonFood >= 10)
                {
                    break;
                }
            }

            if (snakeOutOfTeritory)
            {
                Console.WriteLine("Game over!");
            }
            else
            {
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {eatonFood}");

            for (int row = 0; row < sizeMatrix; row++)
            {
                for (int col = 0; col < sizeMatrix; col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }

       
    }
}
