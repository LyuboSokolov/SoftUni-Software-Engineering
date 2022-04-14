using System;

namespace _02.Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            int myRowPos = 0;
            int myColPos = 0;
            int money = 0;
            for (int row = 0; row < n; row++)
            {
                string currRow = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currRow[col];

                    if (currRow[col] == 'S')
                    {
                        myRowPos = row;
                        myColPos = col;
                    }
                }
            }
            string commmand = Console.ReadLine();
            bool isOutOfBakery = false;

            while (money <= 50)
            {
                int newMyRowPos = myRowPos;
                int newMyColPos = myColPos;

                if (commmand == "up")
                {
                    newMyRowPos--;
                }
                else if (commmand == "down")
                {
                    newMyRowPos++;
                }
                else if (commmand == "left")
                {
                    newMyColPos--;
                }
                else if (commmand == "right")
                {
                    newMyColPos++;
                }

                if (newMyRowPos < 0 || newMyRowPos >= matrix.GetLength(0) || newMyColPos < 0 || newMyColPos >= matrix.GetLength(1))
                {
                    matrix[myRowPos, myColPos] = '-';
                    isOutOfBakery = true;
                    break;
                }
                else
                {
                    if (char.IsDigit(matrix[newMyRowPos, newMyColPos]))
                    {
                        
                        money += int.Parse(matrix[newMyRowPos, newMyColPos].ToString());
                        matrix[myRowPos, myColPos] = '-';
                        matrix[newMyRowPos, newMyColPos] = 'S';
                        myRowPos = newMyRowPos;
                        myColPos = newMyColPos;
                        if (money >=50)
                        {
                            break;
                        }
                    }
                    else if (matrix[newMyRowPos, newMyColPos] == 'O')
                    {
                        matrix[myRowPos, myColPos] = '-';
                        matrix[newMyRowPos, newMyColPos] = '-';

                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                if (matrix[row, col] == 'O')
                                {
                                    matrix[row, col] = 'S';
                                    myRowPos = newMyRowPos = row;
                                    myColPos = newMyRowPos = col;
                                }
                            }
                        }
                    }
                    else
                    {
                        matrix[myRowPos, myColPos] = '-';
                        matrix[newMyRowPos, newMyColPos] = 'S';
                        myRowPos = newMyRowPos;
                        myColPos = newMyColPos;
                    }
                }

                commmand = Console.ReadLine();
            }

            if (isOutOfBakery)
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }
            else
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }

            Console.WriteLine($"Money: {money}");

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
