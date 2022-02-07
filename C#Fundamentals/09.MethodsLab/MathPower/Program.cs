using System;

namespace MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            int numberPow = int.Parse(Console.ReadLine());

            decimal result = NumberPol(number, numberPow);
            Console.WriteLine(result);
        }

        static decimal NumberPol(double number, int numberPow)
        {
            return (decimal)Math.Pow(number, numberPow);

        }
    }
    }
}
