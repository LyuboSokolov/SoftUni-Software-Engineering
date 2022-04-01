using System;
using System.Linq;

namespace _04.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] price = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Func<double[], double[]> func = AddVat;

            double[] result = func(price);

            foreach (var currPrice in result)
            {
                Console.WriteLine($"{currPrice:f2}");
            }
        }
        static double[] AddVat(double[] price)
        {
            double[] result = new double[price.Length];

            for (int i = 0; i < price.Length; i++)
            {
                result[i] = price[i]*1.20;
            }
            return result;
        }
        
    }
}
