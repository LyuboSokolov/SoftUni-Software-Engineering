using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string inputTireInfo = Console.ReadLine();

            List<Tire[]> tires = new List<Tire[]>();

            while (inputTireInfo != "No more tires")
            {
                string[] tokens = inputTireInfo.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Tire[] currTire = new Tire[4];
                for (int i = 0; i < tokens.Length/2 ; i++)
                {
                    int year = int.Parse(tokens[i+i]);
                    double pressure = double.Parse(tokens[i+i + 1]);
                    currTire[i] = new Tire(year, pressure);
                   
                }
                tires.Add(currTire);
                inputTireInfo = Console.ReadLine();
            }

            string inputEngineInfo = Console.ReadLine();

            List<Engine> engines = new List<Engine>();

            while (inputEngineInfo != "Engines done")
            {
                string[] tokens = inputEngineInfo.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < tokens.Length - 1; i += 2)
                {
                    int horsePower = int.Parse(tokens[i]);
                    double cubicCapacity = double.Parse(tokens[i + 1]);
                    Engine currEngine = new Engine(horsePower, cubicCapacity);
                    engines.Add(currEngine);
                }
                inputEngineInfo = Console.ReadLine();
            }

            string inputInfoCar = Console.ReadLine();
            List<Car> cars = new List<Car>();

            while (inputInfoCar != "Show special")
            {
                string[] tokens = inputInfoCar.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string make = tokens[0];
                string model = tokens[1];
                int year = int.Parse(tokens[2]);
                double fuelQuantity = double.Parse(tokens[3]);
                double fuelConsumption = double.Parse(tokens[4]);
                int engineIndex = int.Parse(tokens[5]);
                int tireIndex = int.Parse(tokens[6]);

                Car currCar = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tireIndex]);
                cars.Add(currCar);
                inputInfoCar = Console.ReadLine();
            }

            List<Car> specialCars = new List<Car>();
            foreach (var currCar in cars)
            {
                double sumPressure = 0;
                for (int i = 0; i < currCar.Tires.Length; i++)
                {
                    sumPressure += currCar.Tires[i].Pressure;
                }
                if (currCar.Year >= 2017 && currCar.Engine.HorsePower > 300 && (sumPressure >= 9 && sumPressure <= 10))
                {
                    currCar.FuelQuantity -= 0.20 * currCar.FuelConsumption;
                    specialCars.Add(currCar);
                }
            }

            foreach (var currCar in specialCars)
            {
                Console.WriteLine($"Make: { currCar.Make}");
                Console.WriteLine($"Model: {currCar.Model}");
                Console.WriteLine($"Year: {currCar.Year}");
                Console.WriteLine($"HorsePowers: {currCar.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {currCar.FuelQuantity}");
            }



            //var tires = new Tire[4]
            //{
            //    new Tire(1, 2.5),
            //    new Tire(1, 2.1),
            //    new Tire(2, 0.5),
            //    new Tire(2, 2.3),
            //};

            //var engine = new Engine(560, 6300);

            //var car = new Car("Lamborghini", "Urus", 2010, 250, 9, engine, tires);
        }
    }
}
