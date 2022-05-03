using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double fuelConsumptionIncrease = 1.6;

        public Truck(double fuelQuantity, double literPerKm, double tankCapacity)
              : base(fuelQuantity, literPerKm, tankCapacity, fuelConsumptionIncrease)
        {
        }

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            if (FuelQuantity + liters > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }
            FuelQuantity += liters*0.95;
        }
    }
}
