using System;

namespace BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int beerKegs = int.Parse(Console.ReadLine());
            double volumeKegs = 0;
            double biggestKeg = 0;
            string biggestModelKeg = string.Empty;

            for (int i = 0; i < beerKegs; i++)
            {
                string modelKegs = Console.ReadLine();
                double radiusKegs = double.Parse(Console.ReadLine());
                int heightKegs = int.Parse(Console.ReadLine());

                volumeKegs = Math.PI * (radiusKegs * radiusKegs) * heightKegs;

                if (volumeKegs > biggestKeg)
                {
                    biggestKeg = volumeKegs;
                    biggestModelKeg = modelKegs;
                }

            }
            Console.WriteLine(biggestModelKeg);
        }
    }
}
