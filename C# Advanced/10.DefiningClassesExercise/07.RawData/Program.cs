using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.RawData
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] inputDataCars = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = inputDataCars[0];
                int speed = int.Parse(inputDataCars[1]);
                int power = int.Parse(inputDataCars[2]);
                int weight = int.Parse(inputDataCars[3]);
                string type = inputDataCars[4];
                double tirePressireOne = double.Parse(inputDataCars[5]);
                int tireAgeOne = int.Parse(inputDataCars[6]);
                double tirePressireTwo = double.Parse(inputDataCars[7]);
                int tireAgeTwo = int.Parse(inputDataCars[8]);
                double tirePressireThree = double.Parse(inputDataCars[9]);
                int tireAgeThree = int.Parse(inputDataCars[10]);
                double tirePressireFour = double.Parse(inputDataCars[11]);
                int tireAgeFour = int.Parse(inputDataCars[12]);

                Engine currEngine = new Engine(speed,power);
                Cargo currCargo = new Cargo(weight,type);
                Tire[] tires = new Tire[4]
                {
                    new Tire(tirePressireOne,tireAgeOne),
                    new Tire(tirePressireTwo,tireAgeTwo),
                    new Tire(tirePressireThree,tireAgeThree),
                    new Tire(tirePressireFour,tireAgeFour),
                };
                Car currCar = new Car(model,currEngine,currCargo,tires);
                cars.Add(currCar);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (Car currCar in cars)
                {
                    bool isValidPressure = false;

                    for (int i = 0; i < currCar.Tires.Length; i++)
                    {
                        if (currCar.Tires[i].Pressure < 1)
                        {
                            isValidPressure = true;
                        }
                    }

                    if (currCar.Cargo.Type == "fragile" && isValidPressure)
                    {
                        Console.WriteLine(currCar.Model);
                    }
                }
            }
            else if (command == "flamable")
            {
                foreach (var currCar in cars)
                {
                    if (currCar.Cargo.Type == "flamable" && currCar.Engine.Power > 250)
                    {
                        Console.WriteLine(currCar.Model);
                    }
                }
            }
        }
    }
}
