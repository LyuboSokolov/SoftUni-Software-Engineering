using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private DriverRepository driverRepository = new DriverRepository();
        private RaceRepository raceRepository = new RaceRepository();
        private CarRepository carRepository = new CarRepository();
        public string AddCarToDriver(string driverName, string carModel)
        {
            if (driverRepository.GetByName(driverName) == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }
            if (carRepository.GetByName(carModel) == null)
            {
                throw new InvalidOperationException($"Car { carModel } could not be found.");
            }

            ICar car = carRepository.GetByName(carModel);
            IDriver driver = driverRepository.GetByName(driverName);
            driver.AddCar(car);
            return $"Driver {driverName} received car {carModel}.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = raceRepository.GetByName(raceName);
            IDriver driver = driverRepository.GetByName(driverName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }
            race.AddDriver(driver);
            return $"Driver {driverName} added in {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            Car car = null;
            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }
            if (carRepository.GetAll().Any(p=>p.Model== model) &&
                carRepository.GetAll().Any(p => p.HorsePower== horsePower)) // TODO:
            {
                throw new ArgumentException($"Car {model} is already created.");
            }
            carRepository.Add(car);
            return $"{car.GetType().Name} {model} is created.";
        }

        public string CreateDriver(string driverName)
        {
            
            if (driverRepository.GetAll().Any(p=> p.Name == driverName))
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }
            IDriver driver = new Driver(driverName);
            driverRepository.Add(driver);
            return $"Driver {driverName} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            if (raceRepository.GetAll().Any(p=> p.Name == name))
            {
                throw new InvalidOperationException($"Race {name} is already create.");
            }

            IRace race = new Race(name, laps);
            raceRepository.Add(race);
            return $"Race {name} is created.";
        }

        public string StartRace(string raceName)
        {
            if (raceRepository.GetByName(raceName) == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            IRace race = raceRepository.GetByName(raceName);

            if (race.Drivers.Count<3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            // race.Drivers.OrderByDescending(p => p.Car.CalculateRacePoints(race.Laps));
            string result = string.Empty;
            int count = 0;

            foreach (var driver in race.Drivers.OrderByDescending(p => p.Car.CalculateRacePoints(race.Laps)))
            {
                if (count == 0)
                {
                    result += $"Driver {driver.Name} wins {race.Name} race." + Environment.NewLine;
                    driver.WinRace();
                }
                else if (count == 1)
                {
                    result += $"Driver {driver.Name} is second in {race.Name} race." + Environment.NewLine;
                }
                else if (count == 2)
                {
                    result += $"Driver {driver.Name} is third in {race.Name} race.";
                }
                else
                {
                    break;
                }
                count++;
            }
            raceRepository.Remove(race);
            return result;
           
        }
    }
}
