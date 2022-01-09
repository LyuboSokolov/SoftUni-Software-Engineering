using System;

namespace PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogs = int.Parse(Console.ReadLine());
            int animals = int.Parse(Console.ReadLine());

            double foodFordogs = dogs * 2.50;
            double foodForanimals = animals * 4;
            double allPrice = foodFordogs + foodForanimals;
            Console.WriteLine($"{allPrice:f2} lv.");
        }
    }
}
