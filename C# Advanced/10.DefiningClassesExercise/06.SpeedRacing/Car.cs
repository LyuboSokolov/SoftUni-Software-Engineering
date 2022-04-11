using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKilometer { get; set; }

        public double TravelledDistance { get; set; }


        public static bool IsPossibleToDriveDistance(Car car,double amountOfKm)
        {
            bool isPossibleToDrive = false;

            if (car.FuelAmount >= amountOfKm * car.FuelConsumptionPerKilometer)
            {
                car.FuelAmount -= amountOfKm * car.FuelConsumptionPerKilometer;
                car.TravelledDistance += amountOfKm;
                isPossibleToDrive = true;
            }

            return isPossibleToDrive;
        }
    }

}
