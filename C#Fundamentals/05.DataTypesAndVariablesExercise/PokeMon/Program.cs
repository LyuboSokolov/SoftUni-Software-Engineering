using System;

namespace PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePowerN = int.Parse(Console.ReadLine());
            int pokeTargetsM = int.Parse(Console.ReadLine());
            int exhaustionFactorY = int.Parse(Console.ReadLine());

            int startPowerN = pokePowerN;
            int countTargets = 0;

            double halfPokePowerN = (double)pokePowerN / 2;

            while (pokeTargetsM <= pokePowerN)
            {
                pokePowerN -= pokeTargetsM;
                countTargets++;

                if (halfPokePowerN == pokePowerN)
                {
                    if (pokePowerN != 0 && exhaustionFactorY != 0)
                    {

                        pokePowerN = pokePowerN / exhaustionFactorY;

                    }
                }
            }
            Console.WriteLine(pokePowerN);
            Console.WriteLine(countTargets);
        }
    }
}
