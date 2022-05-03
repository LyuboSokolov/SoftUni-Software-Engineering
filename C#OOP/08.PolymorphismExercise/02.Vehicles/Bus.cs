using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double airConditionConsumption = 1.4;
        public Bus(double fuelQuantity, double literPerKm, double tankCapacity) 
            : base(fuelQuantity, literPerKm, tankCapacity, airConditionConsumption)
        {
        }

       public void DriveEmpty(double distance)
        {
            double fuelNeeded = LitersPerKm * distance;

            if (fuelNeeded > FuelQuantity)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            FuelQuantity -= fuelNeeded;
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }
    }
}
