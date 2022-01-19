using System;

namespace Spaceship
{
    class Program
    {
        static void Main(string[] args)
        {
            double h = double.Parse(Console.ReadLine());
            double l = double.Parse(Console.ReadLine());
            double v = double.Parse(Console.ReadLine());
            double srednaVisochina = double.Parse(Console.ReadLine());

            double space = h * l * v;
            double staq = 2 * 2 * (srednaVisochina + 0.40);
            double spaceForhuman = Math.Floor(space / staq);


            if (spaceForhuman>10)
            {
                Console.WriteLine("The spacecraft is too big.");
            }
            else if (spaceForhuman<3)
            {
                Console.WriteLine("The spacecraft is too small.");
            }
            else
            {
                Console.WriteLine($"The spacecraft holds { spaceForhuman } astronauts." );
            }
        }
    }
}
