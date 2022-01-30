using System;

namespace FloatingEquality
{
    class Program
    {
        static void Main(string[] args)
        {
            double numberA = double.Parse(Console.ReadLine());
            double numberB = double.Parse(Console.ReadLine());

            double precision = Math.Abs(numberA - numberB);

            if (precision < 0.000001)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }
        }
    }
}
