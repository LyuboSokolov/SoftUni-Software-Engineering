using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double fuelConsumptionIncrease = 0.9;

        public Car(double fuelQuantity, double literPerKm, double tankCapacity)
            : base(fuelQuantity, literPerKm,tankCapacity, fuelConsumptionIncrease)
        {
        }
    }
}
