using System;

namespace _02.Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            int currRowPosBee = 0;
            int currColPosBee = 0;
            int pollinatedFlowers = 0;
            

            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];

                    if (input[col] == 'B')
                    {
                        currRowPosBee = row;
                        currColPosBee = col;
                    }
                }
            }

            string command = Console.ReadLine();

            int newRowPosBee = currRowPosBee;
            int newColPosBee = currColPosBee;

            while (command != "End")
            {
                if (command == "up")
                {
                    newRowPosBee -= 1;
                }
                else if (command == "down")
                {
                    newRowPosBee += 1;
                }
                else if (command == "left")
                {
                    newColPosBee -= 1;
                }
                else if (command == "right")
                {
                    newColPosBee += 1;
                }

                if (newRowPosBee >= 0 && newRowPosBee < matrix.GetLength(0) && newColPosBee >= 0 && newColPosBee < matrix.GetLength(1))
                {
                    if (matrix[newRowPosBee, newColPosBee] == 'f')
                    {
                        pollinatedFlowers++;


                    }
                    else if (matrix[newRowPosBee, newColPosBee] == 'O')
                    {
                        matrix[newRowPosBee, newColPosBee] = 'B';
                        matrix[currRowPosBee, currColPosBee] = '.';
                        currRowPosBee = newRowPosBee;
                        currColPosBee = newColPosBee;
                        continue;
                    }

                    matrix[newRowPosBee, newColPosBee] = 'B';
                    matrix[currRowPosBee, currColPosBee] = '.';
                    currRowPosBee = newRowPosBee;
                    currColPosBee = newColPosBee;
                }
                else
                {
                    matrix[currRowPosBee, currColPosBee] = '.';
                    Console.WriteLine("The bee got lost!");

                    break;
                }

                command = Console.ReadLine();
            }

            if (pollinatedFlowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
            }
            else if (pollinatedFlowers < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinatedFlowers} flowers more");
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
