using System;

namespace PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double amountOfMoney = double.Parse(Console.ReadLine());
            int countOfStudents = int.Parse(Console.ReadLine());
            double priceOfLightsabers = double.Parse(Console.ReadLine());
            double priceOfRobes = double.Parse(Console.ReadLine());
            double priceOfBelts = double.Parse(Console.ReadLine());

            double sumLightsabers = 0;
            double sumRobes = 0;
            double sumBelts = 0;
            int freeBelts = 0;
            double totalSum = 0;

            sumLightsabers = (Math.Ceiling(countOfStudents * 1.1)) * priceOfLightsabers;
            sumRobes = priceOfRobes * countOfStudents;

            if (countOfStudents >= 6)
            {
                freeBelts = countOfStudents / 6;
            }

            sumBelts = (countOfStudents - freeBelts) * priceOfBelts;
            totalSum = sumLightsabers + sumRobes + sumBelts;

            if (totalSum > amountOfMoney)
            {
                Console.WriteLine($"Ivan Cho will need {totalSum - amountOfMoney:f2}lv more.");
            }
            else
            {
                Console.WriteLine($"The money is enough - it would cost {totalSum:f2}lv.");
            }
        }
    }
}
