using System;
using System.Text.RegularExpressions;

namespace SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%([A-Z][a-z]+)%.*<(\w+)>.*\|(|[0-9]+)\|\D*([0-9]+\.?[0-9]+)\$";

            string input = Console.ReadLine();

            Regex regex = new Regex(pattern);

            double totalSum = 0;
            while (input != "end of shift")
            {

                Match match = regex.Match(input);

                double sum = 0;

                if (match.Success)
                {
                    string customer = match.Groups[1].ToString();
                    string product = match.Groups[2].ToString();
                    int count = int.Parse(match.Groups[3].ToString());
                    double price = double.Parse(match.Groups[4].ToString());
                    sum = count * price;

                    Console.WriteLine($"{customer}: {product} - {sum:f2}");

                    totalSum += sum;

                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total income: { totalSum:f2}");
        }
    }
}
