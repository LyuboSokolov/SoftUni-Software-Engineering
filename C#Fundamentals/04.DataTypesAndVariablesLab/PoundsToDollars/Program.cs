using System;

namespace PoundsToDollars
{
    class Program
    {
        static void Main(string[] args)
        {
            double pounds = double.Parse(Console.ReadLine());
            decimal dolars = 0;

            dolars = (decimal)pounds * 1.31M;

            Console.WriteLine($"{dolars:f3}");
        }
    }
}
