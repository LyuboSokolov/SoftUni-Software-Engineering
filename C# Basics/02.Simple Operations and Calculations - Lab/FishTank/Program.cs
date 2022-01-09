using System;

namespace FishTank
{
    class Program
    {
        static void Main(string[] args)
        {
            int daljina = int.Parse(Console.ReadLine());
            int shirina = int.Parse(Console.ReadLine());
            int visoxhina = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            int obem = daljina * shirina * visoxhina;
            double obshtolitri = obem * 0.001;
            double litri = obshtolitri * (1 - percent * 0.01);
            Console.WriteLine($"{litri:f3}");
        }
    }
}
