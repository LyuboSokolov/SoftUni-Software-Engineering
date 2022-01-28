using System;

namespace WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int allLitres = 0;

            for (int i = 0; i < n; i++)
            {
                int quantityWater = int.Parse(Console.ReadLine());

                if (allLitres + quantityWater > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    allLitres += quantityWater;
                }
            }
            Console.WriteLine(allLitres);
        }
    }
}
