using System;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            Vehicle car = CreateVehicle();
            Vehicle truck = CreateVehicle();
            Vehicle bus = CreateVehicle();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                string typeVehicle = tokens[1];
                double parameter = double.Parse(tokens[2]);
                try
                {
                    if (typeVehicle == nameof(Car))
                    {
                        ProcessCommand(car, command, parameter);
                    }
                    else if (typeVehicle == nameof(Truck))
                    {
                        ProcessCommand(truck, command, parameter);
                    }
                    else if (typeVehicle == nameof(Bus))
                    {
                        ProcessCommand(bus, command, parameter);
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static void ProcessCommand(Vehicle vehicle, string command, double parameter)
        {
            if (command == "Drive")
            {
                vehicle.Drive(parameter);
            }
            else if (command == "Refuel")
            {
                vehicle.Refuel(parameter);
            }
            else if (command == "DriveEmpty")
            {
                ((Bus)vehicle).DriveEmpty(parameter);
            }

        }

        public static Vehicle CreateVehicle()
        {
            string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string vehicleType = tokens[0];
            double fuelQuantity = double.Parse(tokens[1]);
            double litersPerKm = double.Parse(tokens[2]);
            double tankCapacity = double.Parse(tokens[3]);

            Vehicle vehicle = null;

            if (vehicleType == nameof(Car))
            {
                vehicle = new Car(fuelQuantity, litersPerKm, tankCapacity);
            }
            else if (vehicleType == nameof(Truck))
            {
                vehicle = new Truck(fuelQuantity, litersPerKm, tankCapacity);
            }
            else if (vehicleType == nameof(Bus))
            {
                vehicle = new Bus(fuelQuantity, litersPerKm, tankCapacity);
            }
            return vehicle;
        }
    }
}
