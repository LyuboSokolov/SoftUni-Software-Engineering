using System;
using System.Collections.Generic;
using System.Linq;

namespace P08.CarSalesman
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < n; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = engineInfo[0];
                string power = engineInfo[1];

                if (engineInfo.Length == 2)
                {
                    Engine currEngine = new Engine(model, power);
                    engines.Add(currEngine);
                }
                else if (engineInfo.Length == 3)
                {
                    int displacement = 0;
                    bool isDigit = int.TryParse(engineInfo[2], out displacement);
                    if (isDigit)
                    {
                        Engine currEngine = new Engine(model, power, displacement);
                        engines.Add(currEngine);
                    }
                    else
                    {
                        string efficiency = engineInfo[2];
                        Engine currEngine = new Engine(model, power, efficiency);
                        engines.Add(currEngine);
                    }


                }
                else if (engineInfo.Length == 4)
                {
                    string displacement = engineInfo[2];
                    string efficiency = engineInfo[3];
                    Engine currEngine = new Engine(model, power, displacement, efficiency);
                    engines.Add(currEngine);
                }

            }

            int m = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < m; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = carInfo[0];
                string engineModel = carInfo[1];

                Engine currEngine = engines.FirstOrDefault(x => x.Model == engineModel);
                if (carInfo.Length == 2)
                {
                    Car currCar = new Car(model, currEngine);
                    cars.Add(currCar);
                }
                else if (carInfo.Length == 3)
                {
                    int weight = 0;
                    bool isWeigt = int.TryParse(carInfo[2], out weight);

                    if (isWeigt)
                    {
                        Car currCar = new Car(model, currEngine, weight);
                        cars.Add(currCar);
                    }
                    else
                    {
                        string color = carInfo[2];
                        Car currCar = new Car(model, currEngine, color);
                        cars.Add(currCar);
                    }


                }
                else if (carInfo.Length == 4)
                {
                    string weight = carInfo[2];
                    string color = carInfo[3];
                    Car currCar = new Car(model, currEngine, weight, color);
                    cars.Add(currCar);
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"      Power: {car.Engine.Power}");
                Console.WriteLine($"      Displacement: {car.Engine.Displacement}");
                Console.WriteLine($"      Efficiency: {car.Engine.Efficiency}");
                Console.WriteLine($"  Weight: {car.Weight}");
                Console.WriteLine($"  Color: {car.Color}");
            }

        }
    }
}
