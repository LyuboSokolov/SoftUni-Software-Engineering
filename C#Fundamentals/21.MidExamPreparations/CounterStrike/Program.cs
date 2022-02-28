using System;

namespace CounterStrike
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            int wins = 0;
            bool isDefaut = false;

            while (input?.ToUpper() != "END OF BATTLE")
            {
                int distance = int.Parse(input);

                if (distance <= energy)
                {
                    wins++;
                    energy -= distance;
                }
                else
                {
                    Console.WriteLine($"Not enough energy! Game ends with {wins} won battles and {energy} energy");
                    isDefaut = true;
                    break;
                }

                if (wins % 3 == 0)
                {
                    energy += wins;
                }



                input = Console.ReadLine();
            }

            if (!isDefaut)
            {
                Console.WriteLine($"Won battles: {wins}. Energy left: {energy}");
            }
        }
    }
}
