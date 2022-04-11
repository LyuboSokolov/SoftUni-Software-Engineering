using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Car> car = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputDateCar = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = inputDateCar[0];
                double fuelAmount = double.Parse(inputDateCar[1]);
                double fuelConsumptionPerKilometer = double.Parse(inputDateCar[2]);

                Car currCar = new Car();
                currCar.Model = model;
                currCar.FuelAmount = fuelAmount;
                currCar.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
                car.Add(currCar);
            }

            string inputCommmands = Console.ReadLine();

            while (inputCommmands != "End")
            {
                string[] tokens = inputCommmands.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string carModel = tokens[1];
                double amountOfKm = double.Parse(tokens[2]);

                foreach (var currCar in car)
                {
                    if (currCar.Model == carModel)
                    {
                        if (!Car.IsPossibleToDriveDistance(currCar, amountOfKm))
                        {
                            Console.WriteLine("Insufficient fuel for the drive");
                        }
                    }
                }
                inputCommmands = Console.ReadLine();
            }

            foreach (var currCar in car)
            {
                Console.WriteLine($"{currCar.Model} {currCar.FuelAmount:f2} {currCar.TravelledDistance}");
            }
        }
    }
}
