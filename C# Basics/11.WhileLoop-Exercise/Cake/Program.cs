using System;

namespace Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int l = int.Parse(Console.ReadLine());
            int w = int.Parse(Console.ReadLine());
            string command = string.Empty;
            int cakeSize = 0;
            int piece = 0;
            int allPiece = 0;

            cakeSize = l * w;

            while (command != "STOP" && allPiece < cakeSize)
            {
                command = Console.ReadLine();
                if (command == "STOP")
                {
                    break;
                }
                else
                {
                    piece = int.Parse(command);
                    allPiece += piece;
                }

            }
            if (command == "STOP")
            {
                Console.WriteLine($"{cakeSize - allPiece} pieces are left.");
            }
            if (allPiece > cakeSize)
            {
                Console.WriteLine($"No more cake left! You need {allPiece - cakeSize} pieces more.");
            }
        }
    }
}
