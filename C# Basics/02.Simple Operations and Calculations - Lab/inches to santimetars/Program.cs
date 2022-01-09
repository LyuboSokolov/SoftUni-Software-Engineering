using System;

namespace InchesToCentimeters
{
    class Program
    {
        static void Main(string[] args)
        {
            double input = double.Parse(Console.ReadLine());
            double output = input * 2.54;
            Console.WriteLine(output);
        }
    }
}
