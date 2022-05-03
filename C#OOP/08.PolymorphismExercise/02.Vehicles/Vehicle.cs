using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuntity;

        public Vehicle(double fuelQuantity, double literPerKm, double tankCapacity, double airConditionConsumption)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            LitersPerKm = literPerKm;
            AirConditionConsumption = airConditionConsumption;
        }
        public double FuelQuantity
        {
            get => fuelQuntity;
            protected set
            {
                if (value > TankCapacity)
                {
                    fuelQuntity = 0;
                }
                else
                {
                    fuelQuntity = value;
                }
            }
        }

        public double LitersPerKm { get; private set; }

        public double TankCapacity { get; private set; }

        protected double AirConditionConsumption { get; set; }


        public virtual void Drive(double distance)
        {
            double fuelNeeded = (LitersPerKm + AirConditionConsumption) * distance;

            if (fuelNeeded > FuelQuantity)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            FuelQuantity -= fuelNeeded;
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            if (FuelQuantity + liters > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }
            FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
