using System;
using System.Collections.Generic;

namespace _08.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersOfCarsPassOnGreen = int.Parse(Console.ReadLine());
            int carsPass = numbersOfCarsPassOnGreen;
            string input = Console.ReadLine();

            Queue<string> cars = new Queue<string>();
            int count = 0;

            while (input != "end")
            {
                if (input == "green")
                {
                    if (cars.Count < numbersOfCarsPassOnGreen)
                    {
                        numbersOfCarsPassOnGreen = cars.Count;
                    }
                    for (int i = 0; i < numbersOfCarsPassOnGreen; i++)
                    {
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        count++;
                    }
                    numbersOfCarsPassOnGreen = carsPass;
                }
                else
                {
                    cars.Enqueue(input);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
