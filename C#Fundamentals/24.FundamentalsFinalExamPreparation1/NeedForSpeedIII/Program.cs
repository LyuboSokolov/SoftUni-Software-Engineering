using System;
using System.Collections.Generic;
using System.Linq;

namespace NeedForSpeedIII
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> cars = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] inputCar = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);
                string car = inputCar[0];
                int miliage = int.Parse(inputCar[1]);
                int fuel = int.Parse(inputCar[2]);

                cars.Add(car, new Dictionary<string, int>
                {
                    {"miliage",miliage},
                    {"fuel",fuel}
                });
            }

            string input = Console.ReadLine();

            while (input != "Stop")
            {
                string[] tokens = input.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                string car = tokens[1];

                if (command == "Drive")
                {
                    int distance = int.Parse(tokens[2]);
                    int fuel = int.Parse(tokens[3]);

                    if (cars[car]["fuel"] >= fuel)
                    {
                        cars[car]["fuel"] -= fuel;
                        cars[car]["miliage"] += distance;

                        Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");

                        if (cars[car]["miliage"] >= 100000)
                        {
                            cars.Remove(car);
                            Console.WriteLine($"Time to sell the {car}!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                }
                else if (command == "Refuel")
                {
                    int fuel = int.Parse(tokens[2]);

                    if (cars[car]["fuel"] + fuel >= 75)
                    {

                        Console.WriteLine($"{car} refueled with {75 - cars[car]["fuel"]} liters");
                        cars[car]["fuel"] = 75;
                    }
                    else
                    {
                        cars[car]["fuel"] += fuel;
                        Console.WriteLine($"{car} refueled with {fuel} liters");
                    }

                }
                else if (command == "Revert")
                {
                    int kilometers = int.Parse(tokens[2]);

                    if (cars[car]["miliage"] - kilometers < 10000)
                    {
                        cars[car]["miliage"] = 10000;
                    }
                    else
                    {
                        cars[car]["miliage"] -= kilometers;
                        Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var car in cars.OrderByDescending(n => n.Value["miliage"]).ThenBy(n => n.Key))
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value["miliage"]} kms, Fuel in the tank: {car.Value["fuel"]} lt.");
            }
        }
    }
}
